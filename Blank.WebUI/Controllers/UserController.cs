using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blank.Domain.Abstract;
using Blank.Domain.Entities;

namespace Blank.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository;

        public UserController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        public ViewResult List()
        {
            return View(repository.Users);
        }
    }
}
