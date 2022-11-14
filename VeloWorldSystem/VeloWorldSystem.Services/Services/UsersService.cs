using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.Data;
using VeloWorldSystem.Data.Contracts;
using VeloWorldSystem.DtoModels.Account;
using VeloWorldSystem.Mapping;
using VeloWorldSystem.Models.Entities.Identity;
using VeloWorldSystem.Services.Contracts;

namespace VeloWorldSystem.Services.Services
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableRepository<ApplicationUser> users;

        public UsersService(IDeletableRepository<ApplicationUser> usersParam)
        {
            this.users = usersParam ?? throw new ArgumentNullException(nameof(ApplicationUser));
        }

        public async Task<ApplicationUser> CreateUser(RegisterInputModel model)
        {
            var user = model.To<ApplicationUser>();
            return user;
        }

        public async Task<bool> IsUsernameExistsAsync(string username)
        {
            return await this.users.AllAsNoTracking().AnyAsync(u => u.UserName == username);
        }
    }
}
