using BookStoreCRM.Web.Constants;

namespace BookStoreCRM.Web.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _environment;
    public FileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> UploadFile(Stream stream, string fileName, string folderName)
    {
        if(stream is null)
            throw new ArgumentNullException(nameof(stream));

        if(string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException(
                "File name can not be empty", nameof(fileName));

        var uploadFolder = Path.Combine(
            _environment.WebRootPath, 
            FileConstants.UploadFolder, 
            folderName);

        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }
        var extension = Path.GetExtension(fileName)
            .ToLowerInvariant();

        if (!FileConstants.AllowedExtentions.Contains(extension))
            throw new InvalidOperationException($"File with '{extension}' is not allowed");

        var uniqueFileName = $"{Guid.NewGuid()}{extension}";

        var filePath = Path.Combine(uploadFolder, uniqueFileName);

        await using var fileStream = new FileStream(
            filePath, FileMode.Create);

        await stream.CopyToAsync(fileStream);
        return $"/{FileConstants.UploadFolder}/{folderName}/{uniqueFileName}";
    }
}
