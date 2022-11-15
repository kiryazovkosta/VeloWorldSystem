using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using VeloWorldSystem.Common.Constants;
using VeloWorldSystem.Services.Libraries.Contracts;

namespace VeloWorldSystem.Services.Libraries
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploudAsync(IFormFile file)
        {
            if (file == null || this.IsFileValid(file) == false)
            {
                return GlobalConstants.Images.DefaultAvatarImage;
            }

            string url = " ";
            byte[] fileBytes;
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                fileBytes = stream.ToArray();
            }

            using (var uploadStream = new MemoryStream(fileBytes))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, uploadStream),
                };
                var result = await this.cloudinary.UploadAsync(uploadParams);

                url = result.Url.AbsoluteUri;
            }

            return url;
        }

        public async Task<string> UploudAsync(byte[] file)
        {
            byte[] imageBytes = file;
            string url = " ";

            using (var uploadStream = new MemoryStream(imageBytes))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.ToString(), uploadStream),
                };
                var result = await this.cloudinary.UploadAsync(uploadParams);

                url = result.Url.AbsoluteUri;
            }

            return url;
        }

        public bool IsFileValid(IFormFile photoFile)
        {
            if (photoFile == null)
            {
                return true;
            }

            string[] validTypes = new string[]
            {
                "image/x-png", "image/gif", "image/jpeg", "image/jpg", "image/png", "image/gif",
            };

            if (validTypes.Contains(photoFile.ContentType) == false)
            {
                return false;
            }

            return true;
        }
    }
}
