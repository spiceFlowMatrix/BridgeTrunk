using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bridge.Application.Interfaces;
using Google.Cloud.Storage.V1;

namespace Application.Helpers
{
    public class CommonServices: ICommonServices
    {
        private readonly IBridgeDbContext _dbContext;
       
        public CommonServices(IBridgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string>Geturl(string str, string Certificate)
        {
            string url = "";
            string bucName = "";
            string fileName = "";
            fileName = str.Trim('"');
            string filename = fileName.Split("/").LastOrDefault().Split("?").FirstOrDefault();

            // Here if we add new bucket to google then we need to add another condition for that bucket
            if (str.Contains("edg-primary-course-image-storage"))
            {
                bucName = "edg-primary-course-image-storage";
            }
            else if (str.Contains("edg-primary-profile-image-storage"))
            {
                bucName = "edg-primary-profile-image-storage";
            }
            else if (str.Contains("edg-sales-primary-storage"))
            {
                bucName = "edg-sales-primary-storage";
            }
            else if (str.Contains("t24-primary-audio-storage"))
            {
                bucName = "t24-primary-audio-storage";
            }
            else if (str.Contains("t24-primary-image-storage"))
            {
                bucName = "t24-primary-image-storage";
            }
            else if (str.Contains("t24-primary-pdf-storage"))
            {
                bucName = "t24-primary-pdf-storage";
            }
            else if (str.Contains("t24-primary-video-storage"))
            {
                bucName = "t24-primary-video-storage";
            }
            else
            {
                return str;
            }

            if (bucName == "t24-primary-image-storage")
            {
                return str;
            }
            else
            {
                TimeSpan timeSpan = TimeSpan.FromHours(1);
                double exp = timeSpan.TotalMilliseconds;

                UrlSigner urlSigner = UrlSigner.FromServiceAccountPath(Certificate);
                url = urlSigner.Sign(
                                               bucName,
                                               filename,
                                               timeSpan,
                                               HttpMethod.Get
                                          );

                return url;
            }
        }
    
    }
}