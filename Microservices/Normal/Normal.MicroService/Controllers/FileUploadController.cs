using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Normal.Core.Interfaces.Services;

namespace Normal.MicroService.Controllers
{
    [ApiController]
    [Route("api/normal/say")]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        public FileUploadController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [HttpGet]
        [Route("hello")]
        public async Task<IActionResult> Hello()
        {
            return Ok("Hello dear!");
        }
    }
}
