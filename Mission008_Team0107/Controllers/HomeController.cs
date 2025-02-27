using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission008_Team0107.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission008_Team0107.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", new NewTask());
        }

        [HttpPost]
        public IActionResult AddTask(NewTask response)
        {
            _repo.Tasks.Add(response);
            _repo.SaveChanges();

            return View("Confirmation", response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(NewTask updatedInfo)
        {
            _repo.Update(updatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("QuadrantView");
        }













        //Some base controllers, I;m not sure how things will be called so I'll do something simple for now

        [HttpGet]
        public IActionResult ViewTasks()
        {
            var blah = _repo.Tasks
                .Where(x => x.CreaperStalker == false)
                .OrderBy(x => x.MotherName).ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("WaitList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Applications
                .Single(x => x.ApplicationID == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application record)
        {
            _context.Applications.Remove(record);
            _context.SaveChanges();

            return RedirectToAction("WaitList");
        }


    }
}
