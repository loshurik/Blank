using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Entities;

namespace Blank.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}
