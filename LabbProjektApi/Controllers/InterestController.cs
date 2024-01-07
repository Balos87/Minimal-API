using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabbProjektApi.Controllers
{

    public class InterestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
