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
            //populte category dropdown
            ViewBag.Categories = _repo.Categories
           .OrderBy(x => x.CategoryName)
           .ToList();

            ViewBag.Quadrants = _repo.Quadrants
                .OrderBy(x => x.QuadrantName)
                .ToList();

            ViewBag.Tasks = _repo.Tasks
                .OrderBy(x => x.TaskId)
                .ToList();

            return View("AddTask", new TaskObj());
        }


        [HttpPost]
        public IActionResult AddTask(TaskObj response)
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

            // populate category dropdown
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            ViewBag.Quadrants = _repo.Quadrants
                .OrderBy(x => x.QuadrantName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(TaskObj updatedInfo)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(updatedInfo);
            }
            

            return RedirectToAction("Quadrants");
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
        public IActionResult DeleteTask(TaskObj record)
        {
            _repo.DeleteTask(record);
            //REturn to QuadrantView after deleting an task
            return RedirectToAction("Quadrants");
        }


        //-----------------------------------------------QUADRANT---------------------------------------------


        public IActionResult Quadrants()
        {
            // this is a view model, check for cs files in Models
            var quadInfo = new QuadrantsData
            {
                QuadrantOne =  _repo.GetTasksWithDetails() //It WILL have the Categy and Quad infor because that function I'm calling will join all the talbes together
                        .Where(x => x.QuadrantId == 1 && x.Completed == false)
                        .ToList(), // these commas are needed to seperate the entries
                QuadrantTwo =  _repo.GetTasksWithDetails()
                        .Where(x => x.QuadrantId == 2 && x.Completed == false)
                        .ToList(),
                QuadrantThree =  _repo.GetTasksWithDetails()
                        .Where(x => x.QuadrantId == 3 && x.Completed == false)
                        .ToList(),
                QuadrantFour =  _repo.GetTasksWithDetails()
                        .Where(x => x.QuadrantId == 4 && x.Completed == false)
                        .ToList()
                
            };
 
           

            return View(quadInfo);
        }








    }
}
