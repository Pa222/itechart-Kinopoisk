using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace KinopoiskAPI.Utils.CloudinaryApi
{
    public interface ICloudinaryApi
    {
        public Task<string> GetFileUrl(string name);

        public Task<string> UploadFile(IFormFile file, string userEmail);
    }
}