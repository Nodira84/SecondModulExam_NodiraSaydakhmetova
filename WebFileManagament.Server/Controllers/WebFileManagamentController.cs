using Microsoft.AspNetCore.Mvc;
using WebFileManagament.Service.Services;

namespace WebFileManagament.Server.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class WebFileManagamentController : ControllerBase
    {
        private readonly IWebFileService _webFileService;
        public WebFileManagamentController(IWebFileService webFileService)
        {
            _webFileService = webFileService;
        }

        [HttpPost("uploadFile")]
        public async Task UploadFile(string? directoryPath, IFormFile file)
        {
            directoryPath = directoryPath ?? string.Empty;
            directoryPath = Path.Combine(directoryPath, file.FileName);
            using (var stream = file.OpenReadStream())
            {
                await _webFileService.UploadFileAsync(directoryPath, stream);
            }
        }

        [HttpDelete("deleteFile")]

        public async Task DeleteFile(string filePath)
        {
            await _webFileService.DeleteFileAsync(filePath);
        }

        [HttpDelete("deleteFolder")]
        public async Task DeleteFolder(string directoryPath)
        {
            await _webFileService.DeleteDirectoryAsync(directoryPath);
        }

        [HttpPost("uploadFiles")]
        public async Task UploadFiles(List<IFormFile> files, string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            var mainPath = directoryPath;
            if (files == null || files.Count == 0)
            {
                throw new Exception("files is empty or null");
            }

            foreach (var file in files)
            {
                directoryPath = Path.Combine(mainPath, file.FileName);

                using (var stream = file.OpenReadStream())
                {
                    await _webFileService.UploadFileAsync(directoryPath, stream);
                }
            }
        }


        [HttpPost("createFolder")]
        public async Task CreateFolder(string folderPath)
        {
            await _webFileService.CreatDirectoryAsync(folderPath);
        }

        [HttpGet("getAll")]
        public async Task<List<string>> GetAllInFolderPath(string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            var all = await _webFileService.GetAllFilesAndDirectoriesAsync(directoryPath);
            return all;
        }

        [HttpGet("downloadFile")]
        public async Task<FileStreamResult> DownloadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new Exception("Error");
            }

            var fileName = Path.GetFileName(filePath);

            var stream = await _webFileService.DownloadFileAsync(filePath);


            var res = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = fileName,
            };

            return res;
        }

        [HttpGet("downloadFolderAsZip")]
        public async Task<FileStreamResult> DownloadFolderAsZip(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new Exception("Error");
            }

            var directoryName = Path.GetFileName(directoryPath);

            var stream = await _webFileService.DownloadDirectoryZipAsync(directoryPath);

            try
            {
                var res = new FileStreamResult(stream, "application/octet-stream")
                {
                    FileDownloadName = directoryName + ".zip",
                };

                return res;
            }
            finally
            {
                //_storageService.DeleteFile(directoryPath + ".zip");
            }
        }

    }
}
