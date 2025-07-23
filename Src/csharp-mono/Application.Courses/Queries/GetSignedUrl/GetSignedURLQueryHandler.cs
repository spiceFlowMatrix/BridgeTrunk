using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using MediatR;

namespace Application.Courses.Queries.GetSignedUrl
{
    public class GetSignedURLQueryHandler : IRequestHandler<GetSignedURLQuery, object>
    {
        public async Task<object> Handle(GetSignedURLQuery request, CancellationToken cancellationToken)
        {
            string signedURL = string.Empty;

            try
            {
                string bucketName = Environment.GetEnvironmentVariable("NOON_BUCKET_NAME");

                var scopes = new string[] { "https://www.googleapis.com/auth/devstorage.read_write" };

                ServiceAccountCredential cred;

                using (var stream = new FileStream(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"), FileMode.Open, FileAccess.Read))
                {
                    cred = GoogleCredential.FromStream(stream)
                                           .CreateScoped(scopes)
                                           .UnderlyingCredential as ServiceAccountCredential;
                }

                UrlSigner urlSigner = UrlSigner.FromServiceAccountCredential(cred);

                signedURL = urlSigner.Sign(
                    bucketName,
                    request.ObjectName,
                    TimeSpan.FromMinutes(10),
                    HttpMethod.Put,
                    contentHeaders: new Dictionary<string, IEnumerable<string>> {
                    { 
                        "Content-Type", new[] { request.FileType } 
                    
                    } }
                    );
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return signedURL;
        }
    }
}