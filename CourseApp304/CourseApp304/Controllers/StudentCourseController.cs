using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp304.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp304.Controllers
{
    public class StudentCourseController : Controller
    {
        private DataContext context;

        public StudentCourseController(DataContext _context)    // Dependency injection
        {
            context = _context;
        }

        public IActionResult Index()
        {
            var model = new StudentCourseModel();

            model.Courses = context.Courses
                .Include(x => x.StudentCourses)
                .ThenInclude(x => x.Student)
                .Where(x => x.isActive)
                .ToList();

            model.Students = context.Students
                .Include(x => x.StudentCourses)
                .ThenInclude(x => x.Course)
                .Where(x => x.StudentCourses.Any(a => a.Course.isActive))
                .ToList();

            return View(model);
        }
    }
}