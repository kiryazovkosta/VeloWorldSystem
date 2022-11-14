using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.DtoModels.Account;
using VeloWorldSystem.Models.Entities.Identity;

namespace VeloWorldSystem.Services.Contracts
{
    public interface IUsersService
    {
        Task<bool> IsUsernameExistsAsync(string username);

        Task<ApplicationUser> CreateUser(RegisterInputModel model);
    }
}
