using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeloWorldSystem.Services.Contracts;
using VeloWorldSystem.Web.Extensions;
using static VeloWorldSystem.Common.Constants.DataConstants;

namespace VeloWorldSystem.Web.Controllers
{
    [Authorize(Roles = ApplicationRoleConstants.UsersOnly)]
    public class AuthorizedController : BaseController
    {
        protected readonly IUsersService usersService;

        public AuthorizedController(IUsersService usersServiceParam)
        {
            this.usersService= usersServiceParam;
        }

        public string CurrentUserId => this.User.Id();
    }
}
