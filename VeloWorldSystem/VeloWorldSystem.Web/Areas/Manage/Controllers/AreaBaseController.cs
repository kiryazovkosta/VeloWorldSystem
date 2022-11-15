using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VeloWorldSystem.Web.Areas.Administration.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Administrator")]
    public class AreaBaseController : Controller
    {
    }
}
