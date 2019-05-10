using CourseApp304.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Data.Abstract
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }

        Course GetById(int courseid);
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCoursesByActive(bool isActive);
        IEnumerable<Course> GetCourseByFilter(string name = null, decimal? price = null, string isActive = null, string instructorName = null);
        int CreateCourse(Course newCourse);
        void UpdateCourse(Course updateCourse, Course originalCourse = null);
        void DeleteCourse(int courseid);
        void UpdateAll(int Id, Course[] courses);
    }
}
