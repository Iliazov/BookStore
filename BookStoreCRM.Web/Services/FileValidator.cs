using BookStoreCRM.BLL.Constants;
using BookStoreCRM.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStoreCRM.Web.Services
{
    public class FileValidator : IFileValidator
    {
        public bool Validate(
            IFormFile? file, 
            string propertyName, 
            ModelStateDictionary modelState)
        {
            if (file is null)
            {
                modelState.AddModelError(propertyName, "Please select an Image");
                return false;
            }

            if (file.Length == 0)
            {
                modelState.AddModelError(propertyName, "The selected image is empty");
                return false;
            }

            if (file.Length > FileConstants.MaxFileSize)
            {
                modelState.AddModelError(propertyName, "Maximum file size is 5 MB");
                return false;
            }
            return true;
        }
    }
}
