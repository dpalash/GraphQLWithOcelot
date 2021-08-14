using System.Threading.Tasks;
using Normal.Core.DTOs;
using Normal.Core.Interfaces.Repositories;
using Normal.Core.Interfaces.Services;
using Framework.Core.Logger;
using Framework.Core.Utility;

namespace Normal.Core.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IAuthenticationManagementRepository _authenticationManagementRepository;
        private readonly IProLogger _proLogger;

        public FileUploadService(
            IAuthenticationManagementRepository authenticationManagementRepository,
            IProLogger proLogger)
        {
            _authenticationManagementRepository = authenticationManagementRepository;
            _proLogger = proLogger;
        }

        public async Task<bool> ProcessFileAsync(FileUploadDTO fileUploadDto)
        {
            var uploadResult = false;

            await TryCatchExtension.ExecuteAndHandleErrorAsync(
                async () =>
                {

                },
                ex =>
                {
                    _proLogger.Error($"An error occurred while uploading and processing the file. Error: {ex.Message}");
                    uploadResult = false;

                    return false;
                });

            return uploadResult;
        }
    }
}
