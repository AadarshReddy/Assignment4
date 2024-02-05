using Microsoft.AspNetCore.Mvc;
using Assignment4.Models;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace Assignment4.Controllers
{
    public class TaskController : Controller
    {
        static List<Task1> listtasks = new List<Task1>()
        {
            new Task1{Id=1,Name="Project",Description="creating Plan",DueDate = new DateTime(day:12,month:1,year:2021)},
            new Task1{Id=2,Name="Delivery",Description="Product delivery",DueDate = new DateTime(day:22,month:6,year:2020)},
            new Task1{Id=3,Name="PickUp",Description="Product Pickup",DueDate = new DateTime(day:19,month:7,year:2022)},
            new Task1{Id=4,Name="Packing",Description="Picking Up Product",DueDate = new DateTime(day:29,month:10,year:2008)}
        };
        public IActionResult Index()
        {
            return View(listtasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Task1());
        }
        [HttpPost]
        public IActionResult Create(Task1 task)
        {

            if (task != null)
            {
                if (ModelState.IsValid)
                {
                    listtasks.Add(task);
                    return RedirectToAction("Index");
                }
            }
            return View(task);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Retrieve the task with the given ID
            Task1 taskToDelete = listtasks.FirstOrDefault(t => t.Id == id);

            if (taskToDelete == null)
            {
                // Task not found, return appropriate response (e.g., not found view)
                return NotFound();
            }

            // Pass the task details to the delete view
            return View(taskToDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Find the index of the task with the given ID
            int index = listtasks.FindIndex(t => t.Id == id);

            // Check if task exists
            if (index != -1)
            {
                // Remove the task at the found index
                listtasks.RemoveAt(index);
                return RedirectToAction("Index");
            }
            else
            {
                // If task not found, return appropriate response (e.g., not found view)
                return NotFound();
            }

       
        }
        
        public IActionResult Details()
        {
            return View(listtasks);
        }

    }

}

