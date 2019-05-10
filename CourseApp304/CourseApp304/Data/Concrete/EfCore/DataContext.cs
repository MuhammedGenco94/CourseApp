using CourseApp304.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<Request> Requests { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Student> Students { get; set; }

        //public DbSet<StudentAddress> StudentAddresses { get; set; }       // Bunu oluşturmaya gerek yok, kendisi oluşturacak bağlantılı olduğu için.
    }
}
