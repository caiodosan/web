using Microsoft.AspNetCore.Mvc;

namespace dashboard.Controllers
{
    public class graph : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}
