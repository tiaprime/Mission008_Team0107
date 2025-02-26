using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission008_Team0107.Models;

namespace Mission008_Team0107.Controllers
{
    public class HomeController : Controller
    {
        private NewTaskContext _context;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", new NewTask());
        }

        [HttpPost]
        public IActionResult AddTask(NewTask response)
        {
            _context.Tasks.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(NewTask updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("QuadrantView");
        }

    }
}
