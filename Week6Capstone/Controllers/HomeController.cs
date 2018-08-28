using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Week6Capstone.Models;

namespace Week6Capstone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            tasklistEntities ORM = new tasklistEntities();

            ViewBag.Tasks = ORM.tasks.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddTask()
        {
            return View();
        }

        public ActionResult SaveNewTask(task newTask)
        {
            tasklistEntities ORM = new tasklistEntities();

            ORM.tasks.Add(newTask);

            ORM.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CompleteTask(int taskid)
        {
            tasklistEntities ORM = new tasklistEntities();

            task TaskToComplete = ORM.tasks.Find(taskid);
            if (TaskToComplete.status == false)
            {
                TaskToComplete.status = true;
            }
            else
            {
                TaskToComplete.status = false;
            }

            ORM.Entry(TaskToComplete).State = System.Data.Entity.EntityState.Modified;

            ORM.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteTask(int taskid)
        {
            tasklistEntities ORM = new tasklistEntities();

            task TaskToDelete = ORM.tasks.Find(taskid);

            ORM.tasks.Remove(TaskToDelete);

            ORM.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}