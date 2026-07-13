using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStoreCRM.Web.Services.Interfaces
{
    public interface IFileValidator
    {
        bool Validate(
            IFormFile? file, 
            string propertyName,
            ModelStateDictionary modelState);
    }
}
