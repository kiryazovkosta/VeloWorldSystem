namespace VeloWorldSystem.Web.Infrastructure.Attributes
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using VeloWorldSystem.Common.Constants;

    public class ValidateImageFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
            {
                return true;
            }

            IFormFile image = value as IFormFile;
            if (image == null) 
            {
                return false;
            }

            if (image.Length > GlobalConstants.Images.MaxFileLengthInBytes)
            {
                return false;
            }

            var imageContentType = image.ContentType.ToLower();
            if (!GlobalConstants.Images.ValidImageContentTypes.Contains(imageContentType))
            {
                return false;
            }

            return true;
        }
    }
}