using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace KinopoiskAPI.Utils.CloudinaryApi
{
    public interface ICloudinaryApi
    {
        public Task<string> GetFileUrl(string name);

        public Task<string> UploadFile(IFormFile file, string userEmail);
    }
}