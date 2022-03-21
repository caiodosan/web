using dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dashboard.Controllers
{
    public class transactions : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}
