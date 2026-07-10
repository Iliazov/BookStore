namespace BookStoreCRM.Web.Constants;

public static class FileConstants
{
    public const string UploadFolder = "uploads";
    public const int MaxFileSize = 5 * 1024 * 1024;
    public static readonly string[] AllowedExtentions =
    {
        ".jpg",
        ".jpeg",
        ".png",
        ".webp"
    };
}
