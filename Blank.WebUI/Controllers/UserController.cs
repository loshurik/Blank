using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blank.Domain.Abstract;
using Blank.Domain.Entities;
using Blank.WebUI.Models;

namespace Blank.WebUI.Controllers
{
    public class UserController : Controller
    {
        public int PageSize = 2;
        private IUserRepository repository;

        public UserController(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        public ViewResult List( int page = 1)
        {
            UserListViewModel viewModel = new UserListViewModel
            {
                Users = repository.Users
                //.Where(p=>p.City==null||p.City==city)
                .OrderBy(p => p.Age)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo 
                {
                    CurrentPage=page,
                    ItemsPerPage=PageSize,
                    TotalItems=repository.Users.Count()
                },
              //  CurrentCategory=city
            };
            return View(viewModel);
        }
    }
}
