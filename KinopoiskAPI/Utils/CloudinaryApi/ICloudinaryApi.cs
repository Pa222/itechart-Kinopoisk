using System.Threading.Tasks;
using CloudinaryDotNet.Actions;

namespace KinopoiskAPI.Utils.CloudinaryApi
{
    public interface ICloudinaryApi
    {
        public Task<string> GetFileUrl(string name);
    }
}