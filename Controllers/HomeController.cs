using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project_1.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext tContext { get; set; }
        public HomeController(TaskContext x)
        {
            tContext = x;
        }


        // INDEX 
        public IActionResult Index()
        {
            return View();
        }

        // QUADRANTS PAGE
        public IActionResult TaskQuadrants()
        {
            var tasks = tContext.Tasks
                .Include(x => x.Category)
                .ToList();

            return View(tasks);
        }


        // ADD TASKS
        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = tContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult TaskForm(Task t)
        {
            if (ModelState.IsValid)
            {
                tContext.Add(t);
                tContext.SaveChanges();

                return RedirectToAction("TaskQuadrants");
            }
            else
            {
                ViewBag.Categories = tContext.Categories.ToList();
                return View(t);
            }
        }


        // EDIT TASK
        [HttpGet]
        public IActionResult EditTask(int taskid)
        {
            ViewBag.Categories = tContext.Categories.ToList();

            var task = tContext.Tasks.Single(x => x.TaskId == taskid);
            return View("TaskForm", task);
        }

        [HttpPost]
        public IActionResult EditTask(Task t)
        {
            tContext.Update(t);
            tContext.SaveChanges();

            return RedirectToAction("TaskQuadrants");
        }


        // Delete task
        [HttpGet]
        public IActionResult DeleteTask(int taskid)
        {
            var task = tContext.Tasks.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteTask(Task t)
        {
            tContext.Tasks.Remove(t);
            tContext.SaveChanges();

            return RedirectToAction("TaskQuadrants");
        }
    }
}