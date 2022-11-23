namespace VeloWorldSystem.Services.Libraries
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using VeloWorldSystem.Common.Exceptions;
    using VeloWorldSystem.Services.Libraries.Contracts;
    using static VeloWorldSystem.Common.Constants.DataConstants;
    using static VeloWorldSystem.Common.Constants.GlobalErrorMessages;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary ?? throw new ArgumentNullException(nameof(Cloudinary));
        }

        public async Task<string> UploudAsync(IFormFile file)
        {
            if (file == null || this.IsFileValid(file) == false)
            {
                throw new CloudinaryUploadException(CloudinaryErrors.ExceptionMessage);
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

        public async Task<string> UploudArrayAsync(byte[] file)
        {
            if (file == null || file.Length == 0)
            {
                throw new CloudinaryUploadException(CloudinaryErrors.ExceptionMessage);
            }

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
                return false;
            }

            if (CloudinaryConstants.ValidImagesTypes.Contains(photoFile.ContentType) == false)
            {
                return false;
            }

            return true;
        }
    }
}
