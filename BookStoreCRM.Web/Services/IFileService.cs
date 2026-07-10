namespace BookStoreCRM.Web.Services;

public interface IFileService
{
    Task<string> UploadFile(Stream stream, string fileName, string folderName);
}
