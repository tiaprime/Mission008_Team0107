using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission008_Team0107.Models;

namespace Mission008_Team0107.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

  
    }
}
