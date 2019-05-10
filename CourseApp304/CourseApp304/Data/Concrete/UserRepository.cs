using CourseApp304.Data.Abstract;
using CourseApp304.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Data.Concrete
{
    public class UserRepository : IUserRepository
    {
        private UserContext context;

        public UserRepository(UserContext _context)
        {
            context = _context;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }
    }
}
