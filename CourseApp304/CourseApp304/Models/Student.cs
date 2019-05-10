using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public StudentAddress Address { get; set; }     // (One to One) bağlantısını oluşturuyor
        public IEnumerable<StudentCourse> StudentCourses { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
