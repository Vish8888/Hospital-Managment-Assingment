using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managment.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
