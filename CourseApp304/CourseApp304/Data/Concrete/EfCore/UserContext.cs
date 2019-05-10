using CourseApp304.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext>context):base(context)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
