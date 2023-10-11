using EventHubWebApi.Services.ImageManagerService;
using Microsoft.AspNetCore.StaticFiles;
using API.FileProcessing.Helper;
using EventHubWebApi.Data;

namespace EventHubWebApi.Services.ManageImageService
{
    public class ManageImageService : IManageImagecs
    {
        private readonly AppDbContext _context;
        public ManageImageService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> UploadFile(IFormFile _IFormFile, int eventid)
        {
            string FileName = eventid.ToString();
            try
            {
                FileInfo _FileInfo = new FileInfo(_IFormFile.FileName);
                FileName += "_" +  _IFormFile.FileName;
                var _GetFilePath = Common.GetFilePath(FileName);
                using (var _FileStream = new FileStream(_GetFilePath, FileMode.Create))
                {
                    await _IFormFile.CopyToAsync(_FileStream);
                }

                EventImages eventImages = new EventImages();
                eventImages.EventId = eventid;
                eventImages.ImgaePath = FileName;

                _context.EventImages.Add(eventImages);
                await _context.SaveChangesAsync();

                return FileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<(Stream, string, string)> DownloadFile(string FileName)
        {
            try
            {
                var filePath = Common.GetFilePath(FileName);
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(filePath, out var contentType))
                {
                    contentType = "application/octet-stream";
                }

                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var memoryStream = new MemoryStream();
                await fileStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0; // Reset the stream position to the beginning

                return (memoryStream, contentType, Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
