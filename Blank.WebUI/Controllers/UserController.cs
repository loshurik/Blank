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
        public int PageSize = 4;
        private IUserRepository repository;

        public UserController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        public ViewResult List(int page = 1)
        {
            return View(repository.Users
                .OrderBy(p => p.Age)
                .Skip((page-1)*PageSize)
                .Take(PageSize));
        }
    }
}
