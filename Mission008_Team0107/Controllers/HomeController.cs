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


        //-----------------------------------------------TASK-------------------------------------------------
        
        
        //ADD  0-- view tasks
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Tasks = _repo.Tasks
                .OrderBy(x => x.TaskId)
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

        //EDIT
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

        //DELETE

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult DeleteTask(Task record)
        {
            _repo.DeleteTask(record);
            //REturn to QuadrantView after deleting an task
            return RedirectToAction("QuadrantView");
        }


        //-----------------------------------------------QUADRANT---------------------------------------------


        public IActionResult SeeQuandrent()
        {
            ViewBag.Tasks = _repo.Tasks
            .OrderBy(x => x.TaskId)
            .Where(x => x.Completed == false)
            .ToList();
            return View();
        }








    }
}
