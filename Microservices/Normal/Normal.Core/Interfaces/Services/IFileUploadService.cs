using System.Threading.Tasks;
using Normal.Core.DTOs;

namespace Normal.Core.Interfaces.Services
{
    public interface IFileUploadService
    {
        Task<bool> ProcessFileAsync(FileUploadDTO fileUploadDto);
    }
}