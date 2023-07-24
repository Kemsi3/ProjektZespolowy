using Microsoft.AspNetCore.Mvc;


namespace CostSplitterAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AddBill()
        {
            return View();
        }
    }
}
