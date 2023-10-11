namespace EventHubWebApi.Services.ImageManagerService
{
    public interface IManageImagecs
    {
        Task<string> UploadFile(IFormFile _IFormFile, int eventId);

        Task<(Stream, string, string)> DownloadFile(string FileName);
    }
}
