using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blank.Domain.Entities;

namespace Blank.WebUI.Models
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PagingInfo PagingInfo { get; set; }
      //  public string CurrentCategory { get; set; }
    }
}