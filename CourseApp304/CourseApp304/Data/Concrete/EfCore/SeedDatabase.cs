using CourseApp304.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Models
{
    public static class SeedDatabase
    {
        public static void Seed(DbContext context)
        {
            if (!context.Database.GetPendingMigrations().Any())          //context.Database.GetPendingMigrations().Count() == 0
            {
                if (context is DataContext)
                {
                    DataContext _context = context as DataContext;
                    if (!_context.Courses.Any())                         //_context.Courses.Count() == 0
                    {
                        _context.Courses.AddRange(Courses);
                    }
                    if (!_context.Instructors.Any())                     //_context.Instructors.Count() == 0
                    {
                        _context.Instructors.AddRange(Instructors);
                    }
                    if (!_context.Students.Any())
                    {
                        _context.Students.AddRange(Students);
                    }
                }

                if (context is UserContext)
                {
                    UserContext _context = context as UserContext;
                    if (_context.Users.Count() == 0)
                    {
                        _context.Users.AddRange(Users);
                    }
                }
                context.SaveChanges();
            }
        }

        private static Course[] Courses
        {
            get
            {
                Course[] courses = new Course[]
                {
                new Course() {Name="Html",Price=50,Description="About Html",isActive=true,Instructor=Instructors[0]},
                new Course() {Name="Css",Price=100,Description="About Css",isActive=true,Instructor=Instructors[1]},
                new Course() {Name="JavaScript",Price=70,Description="About JavaScript",isActive=true,Instructor=Instructors[2]},
                new Course() {Name="NodeJs",Price=90,Description="About NodeJs",isActive=false,Instructor=Instructors[3]},
                new Course() {Name="Angular",Price=200,Description="About Angular",isActive=true,Instructor=Instructors[4]},
                new Course() {Name="React",Price=150,Description="About React",isActive=false,Instructor=Instructors[5]},
                new Course() {Name="Asp.Net.Mvc",Price=400,Description="About Asp.Net.Mvc",isActive=true,Instructor=Instructors[0]},
                new Course() {Name="Asp.Net.Core",Price=600,Description="About Asp.Net.Core",isActive=true,Instructor=Instructors[0]}
                };
                return courses;
            }
        }

        private static Student[] Students
        {
            get
            {
                Student[] students = new Student[]
                {
                    new Student(){Name="Student1"},
                    new Student(){Name="Student2"},
                    new Student(){Name="Student3"},
                    new Student(){Name="Student4"},
                    new Student(){Name="Student5"}
                };
                return students;
            }
        }

        public static Instructor[] Instructors =
        {
            new Instructor() {Name="Emre Gençkaya",Contact=new Contact(){ Email="emregenckaya@gmail.com",Phone="5543446633",Address=new Address(){City="İstanbul",Country="Türkiye",Text="Güzeltepe Mah."} }},
            new Instructor() {Name="Enes Gençkaya",Contact=new Contact(){ Email="enesgenckaya@gmail.com",Phone="5543446633",Address=new Address(){City="İstanbul",Country="Türkiye",Text="Güzeltepe Mah."} }},
            new Instructor() {Name="Melek Subaşı",Contact=new Contact(){ Email="meleksubasi@gmail.com",Phone="5543446633",Address=new Address(){City="Muş",Country="Türkiye",Text="Tüpbitti Mah."} }},
            new Instructor() {Name="Selim Ağca",Contact=new Contact(){ Email="selimagca@gmail.com",Phone="5543446633",Address=new Address(){City="Malatya",Country="Türkiye",Text="Esenler Mah."} }},
            new Instructor() {Name="Emre Karadağ",Contact=new Contact(){ Email="emrekaradag@gmail.com",Phone="5543446633",Address=new Address(){City="Gaziantep",Country="Türkiye",Text="Rıhtım Mah."} }},
            new Instructor() {Name="Onur Müderrisoğlu",Contact=new Contact(){ Email="onurmuderrisoglu@gmail.com",Phone="5543446633",Address=new Address(){City="İstanbul",Country="Türkiye",Text="İstanbul Mah."} }}
        };


        private static User[] Users =
        {
            new User(){UserName="muhammedgenco",Email="muhamed.genco@gmail.com",Password="123456789",City="İstanbul"},
            new User(){UserName="enesgenckaya",Email="enes@gmail.com",Password="12345",City="İstanbul"},
            new User(){UserName="selimagca",Email="selim@gmail.com",Password="12345",City="İstanbul"}
        };

    }
}