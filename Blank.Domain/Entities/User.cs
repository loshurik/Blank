using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
    }
}
