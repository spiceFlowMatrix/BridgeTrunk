using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Models;
using Microsoft.AspNetCore.Hosting;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;
using MediatR;

namespace Application.Courses.Queries.GetConvertedUrl
{
    public class GetConvertedUrlQueryHandler : IRequestHandler<GetConvertedUrlQuery, ApiResponse>
    {
        private readonly IHostingEnvironment _env;
        public GetConvertedUrlQueryHandler(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task<ApiResponse> Handle(GetConvertedUrlQuery request, CancellationToken cancellationToken)
        {
            ApiResponse res = new ApiResponse();
            GoogleCredential cred;
            try
            {
                // note: Read credential from local for testing.
                using (var stream = new FileStream(Path.GetFileName("../../training24-28e994f9833c.json"), FileMode.Open, FileAccess.Read))
                {
                    cred = GoogleCredential.FromStream(stream);
                }
                // Note: read cred from environnment
                // using (var stream = new FileStream(Environment.GetEnvironmentVariable ("GOOGLE_APPLICATION_CREDENTIALS"), FileMode.Open, FileAccess.Read))
                // {
                //     cred = GoogleCredential.FromStream(stream);
                // }

                var _storageClient = StorageClient.Create(cred);

                // string Authorization = Request.Headers["id_token"];

                // TokenClaims tc = General.GetClaims(Authorization);
                // tc.Id = LessonBusiness.getUserId(tc.sub);

                // if (
                // tc.RoleName.Contains(General.getRoleType("1")) ||
                // tc.RoleName.Contains(General.getRoleType("3"))
                // )
                // {
                foreach (var obj in _storageClient.ListObjects("edg-primary-course-image-storage", ""))
                {
                    if (obj.MediaLink == "https://www.googleapis.com/download/storage/v1/b/edg-primary-course-image-storage/o/splash_b6225b52-ffce-4c6b-ad68-4e03eb31eccd.png?generation=1537353117899874&alt=media")
                    {
                        string str = "";
                    }

                }
                res.data = null;
                res.response_code = 0;
                res.message = "file converted";
                res.status = "Success";
                res.ReturnCode = 200;
            }
            catch (Exception ex)
            {
                res.ReturnCode = 500;
                res.response_code = 2;
                res.message = ex.Message;
                res.status = "Failure";
            }
            return res;
        }
    }
}