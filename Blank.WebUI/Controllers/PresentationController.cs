using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseClassLibrary;

namespace Blank.WebUI.Controllers
{ 
    public class PresentationController : Controller
    {
        private GlobalBaseEntities db = new GlobalBaseEntities();

        public ViewResult Index()
        {
            var presentation = db.Presentation.Include("User");
            return View(presentation.ToList());
        }

        public ViewResult List()
        {
            var presentation = db.Presentation.Include("User");
            ViewBag.MyList = presentation.Where(p => p.User.Name == "vera").ToList();
            return View();
        }

        public ViewResult Details(int id)
        {
            Presentation presentation = db.Presentation.Single(p => p.Id == id);
            return View(presentation);
        }

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.User, "Id", "Name");
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Presentation presentation)
        {
            if (ModelState.IsValid)
            {
                db.Presentation.AddObject(presentation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.UserId = new SelectList(db.User, "Id", "Name", presentation.UserId);
            return View(presentation);
        }
        
        public ActionResult Edit(int id)
        {
            Presentation presentation = db.Presentation.Single(p => p.Id == id);
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", presentation.UserId);
            return View(presentation);
        }

        [HttpPost]
        public ActionResult Edit(Presentation presentation)
        {
            if (ModelState.IsValid)
            {
                db.Presentation.Attach(presentation);
                db.ObjectStateManager.ChangeObjectState(presentation, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.User, "Id", "Name", presentation.UserId);
            return View(presentation);
        }

        public ActionResult Delete(int id)
        {
            Presentation presentation = db.Presentation.Single(p => p.Id == id);
            return View(presentation);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Presentation presentation = db.Presentation.Single(p => p.Id == id);
            db.Presentation.DeleteObject(presentation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}