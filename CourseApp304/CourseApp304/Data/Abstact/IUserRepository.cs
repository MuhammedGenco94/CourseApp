using CourseApp304.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Data.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
