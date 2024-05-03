using Microsoft.AspNetCore.Http;


namespace Tune_Star.BLL.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile file, string uploadFolder);
        Task<string> SaveAudioAsync(IFormFile file, string uploadFolder);
    }
}

