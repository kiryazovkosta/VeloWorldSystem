namespace VeloWorldSystem.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using VeloWorldSystem.Common.Constants;
    using VeloWorldSystem.Data.Contracts;
    using VeloWorldSystem.DtoModels.Account;
    using VeloWorldSystem.Mapping;
    using VeloWorldSystem.Models.Entities.Identity;
    using VeloWorldSystem.Services.Contracts;
    using VeloWorldSystem.Services.Libraries;
    using VeloWorldSystem.Services.Libraries.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IDeletableRepository<ApplicationUser> users;

        private readonly ICloudinaryService cloudinary;

        public UsersService(
            IDeletableRepository<ApplicationUser> usersParam, 
            ICloudinaryService cloudinaryParam)
        {
            this.users = usersParam ?? throw new ArgumentNullException(nameof(ApplicationUser));
            this.cloudinary = cloudinaryParam ?? throw new ArgumentNullException(nameof(CloudinaryService));
        }

        public async Task<ApplicationUser> CreateUser(RegisterInputModel model)
        {
            var user = model.To<ApplicationUser>();
            if (model.Avatar != null && cloudinary.IsFileValid(model.Avatar)) 
            {
                try
                {
                    user.ImageUrl = await this.cloudinary.UploudAsync(model.Avatar);
                }
                catch (Exception)
                {
                    user.ImageUrl = GlobalConstants.Images.DefaultAvatarImage;
                }
            }
            else
            {
                user.ImageUrl = GlobalConstants.Images.DefaultAvatarImage;
            }

            return user;
        }

        public async Task<bool> IsUserExistsAsync(string userId)
        {
            return await this.users.AllAsNoTracking().AnyAsync(u => u.Id == userId);
        }

        public async Task<bool> IsUsernameExistsAsync(string username)
        {
            return await this.users.AllAsNoTracking().AnyAsync(u => u.UserName == username);
        }
    }
}
