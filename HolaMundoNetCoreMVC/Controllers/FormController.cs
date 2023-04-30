using Microsoft.AspNetCore.Mvc;

namespace HolaMundoNetCoreMVC.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
