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
    public class QwertyController : Controller
    {
        private GlobalBaseEntities db = new GlobalBaseEntities();

        //
        // GET: /Qwerty/

        public ViewResult Index()
        {
            var user = db.User.Include("Role");
            return View(user.ToList());
        }

        //
        // GET: /Qwerty/Details/5

        public ViewResult Details(int id)
        {
            User user = db.User.Single(u => u.Id == id);
            return View(user);
        }

        //
        // GET: /Qwerty/Create

        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name");
            return View();
        } 

        //
        // POST: /Qwerty/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.User.AddObject(user);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name", user.RoleId);
            return View(user);
        }
        
        //
        // GET: /Qwerty/Edit/5
 
        public ActionResult Edit(int id)
        {
            User user = db.User.Single(u => u.Id == id);
            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name", user.RoleId);
            return View(user);
        }

        //
        // POST: /Qwerty/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Attach(user);
                db.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name", user.RoleId);
            return View(user);
        }

        //
        // GET: /Qwerty/Delete/5
 
        public ActionResult Delete(int id)
        {
            User user = db.User.Single(u => u.Id == id);
            return View(user);
        }

        //
        // POST: /Qwerty/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            User user = db.User.Single(u => u.Id == id);
            db.User.DeleteObject(user);
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