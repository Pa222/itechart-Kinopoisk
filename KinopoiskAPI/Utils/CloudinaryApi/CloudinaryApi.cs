using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace KinopoiskAPI.Utils.CloudinaryApi
{
    public class CloudinaryApi : ICloudinaryApi
    {
        private readonly Cloudinary _cloudinaryApi;
        public IConfiguration Configuration { get; }

        public CloudinaryApi(IConfiguration configuration)
        {
            Configuration = configuration;
            var account = new Account(
                Configuration["Cloudinary:cloudName"],
                Configuration["Cloudinary:apiKey"],
                Configuration["Cloudinary:apiSecret"]
                );

            _cloudinaryApi = new Cloudinary(account)
            {
                Api =
                {
                    Secure = true
                }
            };
        }

        public async Task<string> GetFileUrl(string name)
        {
            var tmp = await _cloudinaryApi.ListResourcesAsync(new ListResourcesParams()
            {
                MaxResults = int.MaxValue
            });
            return tmp.Resources.FirstOrDefault(resource => resource.PublicId.ToLower().Contains(name.ToLower()))?.Url.AbsoluteUri;
        }

        public async Task<string> UploadFile(IFormFile file, string userEmail)
        {
            var uploadResult = await _cloudinaryApi.UploadAsync(new ImageUploadParams
            {
                File = new FileDescription(userEmail, file.OpenReadStream()),
                Folder = "UserAvatars",
                Overwrite = true,
                UseFilename = true,
                UniqueFilename = false,
            });
            return uploadResult.StatusCode == HttpStatusCode.OK ? uploadResult.Url.AbsoluteUri : null;
        }
    }
}