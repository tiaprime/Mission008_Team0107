using System.Diagnostics;   
using Microsoft.AspNetCore.Mvc;
using Mission008_Team0107.Models;

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


        //CADEN-----------------------------
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", new Task());
        }


        [HttpPost]
        public IActionResult AddTask(Task response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response);
            }


            return View("Confirmation", response);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            //ViewBag.Categories = _repo.Categories
            //    .OrderBy(x => x.CategoryName)
            //    .ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task updatedInfo)
        {
            _repo.UpdateTask(updatedInfo);

            return RedirectToAction("QuadrantView");
        }


    }
}
