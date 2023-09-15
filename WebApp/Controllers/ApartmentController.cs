using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ApartmentController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
