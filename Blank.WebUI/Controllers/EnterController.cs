using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseClassLibrary;
using System.Web.Security;

namespace Blank.WebUI.Controllers
{ 
    public class EnterController : Controller
    {
        private GlobalBaseEntities db = new GlobalBaseEntities();

        //
        // GET: /Enter/

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                
                if (true)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Enter");
                }
                else
                {
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(User model, string returnUrl)
        {
            return RedirectToAction("Index", "Enter");
            //return View(model);
        }

        public ViewResult Index()
        {
            var user = db.User.Include("Role");
            return View(user.ToList());
        }

        [HttpPost]
        public ActionResult LogOn(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //if (Membership.ValidateUser(model.Name, model.Password))
                if (true)
                {
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Enter");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Enter/Details/5

        public ViewResult Details(int id)
        {
            User user = db.User.Single(u => u.Id == id);
            return View(user);
        }

        //
        // GET: /Enter/Create

        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name");
            return View();
        } 

        //
        // POST: /Enter/Create

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
        // GET: /Enter/Edit/5
 
        public ActionResult Edit(int id)
        {
            User user = db.User.Single(u => u.Id == id);
            ViewBag.RoleId = new SelectList(db.Role, "Id", "Name", user.RoleId);
            return View(user);
        }

        //
        // POST: /Enter/Edit/5

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
        // GET: /Enter/Delete/5
 
        public ActionResult Delete(int id)
        {
            User user = db.User.Single(u => u.Id == id);
            return View(user);
        }

        //
        // POST: /Enter/Delete/5

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
         #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}


