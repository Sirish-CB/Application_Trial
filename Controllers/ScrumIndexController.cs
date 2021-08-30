using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Application_Trial.Models;

namespace Application_Trial.Controllers
{
    public class ScrumIndexController : Controller
    {
        // GET: ScrumIndex
        TaskDataAccess objtask = new TaskDataAccess();
        StoryDataAccessLayer objst = new StoryDataAccessLayer();
        public ActionResult ScrumMain()
        {
            return View();
        }
        public ActionResult StoriesPartialView()
        {
            List<Story> LstStrory = new List<Story>();
            LstStrory = objst.GetAllStories().ToList();
            return View(LstStrory);
        }
        public ActionResult NotStartedPartialView()
        {
            List<Taski> LstSTTask = new List<Taski>();
            LstSTTask = objtask.GetAllStatusTasks("Not Started").ToList();
            return View(LstSTTask);
        }
        public ActionResult InProgressPartialView()
        {
            List<Taski> LstSTTask = new List<Taski>();
            LstSTTask = objtask.GetAllStatusTasks("In Progress").ToList();
            return View(LstSTTask);
        }
        public ActionResult CompletedPartialView()
        {
            List<Taski> LstSTTask = new List<Taski>();
            LstSTTask = objtask.GetAllStatusTasks("Completed").ToList();
            return View(LstSTTask);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Story story)
        {
            if (ModelState.IsValid)
            {
                objst.AddStory(story);
                return RedirectToAction("ScrumMain");
            }
            return View(story);

        }
        [HttpGet]
        public ActionResult CreateTable()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTable([Bind] Taski task)
        {
            if (ModelState.IsValid)
            {
                objtask.AddTask(task);
                return RedirectToAction("ScrumMain");
            }
            return View(task);

        }
        ///////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Taski task = objtask.GetTask(id);

            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] Taski task)
        {
            if (id != task.TaskID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objtask.UpdateTask(task);
                return RedirectToAction("ScrumMain");
            }
            return View(task);
        }
        private ActionResult NotFound()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public ActionResult EditStory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Story story = objst.GetStory(id);

            if (story == null)
            {
                return NotFound();
            }
            return View(story);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStory(int id, [Bind] Story story)
        {
            if (id != story.StoryID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objst.UpdateStory(story);
                return RedirectToAction("ScrumMain");
            }
            return View(story);
        }
        /////////////////////////////////////////////
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Taski task = objtask.GetTask(id);

            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }
        /////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Taski task = objtask.GetTask(id);

            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            objtask.DeleteTask(id);
            return RedirectToAction("ScrumMain");
        }

        [HttpGet]
        public ActionResult DeleteStory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Story story = objst.GetStory(id);

            if (story == null)
            {
                return NotFound();
            }
            return View(story);
        }

        [HttpPost, ActionName("DeleteStory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStoryConfirmed(int? id)
        {
            objst.DeleteStory(id);
            return RedirectToAction("ScrumMain");
        }



    }
}

