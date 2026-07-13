namespace BookStoreCRM.Web.Services.Interfaces;

public interface IFileService
{
    Task<string> UploadFile(
        Stream stream, 
        string fileName, 
        string folderName);

    Task DeleteAsync(string? relativePath);
}
