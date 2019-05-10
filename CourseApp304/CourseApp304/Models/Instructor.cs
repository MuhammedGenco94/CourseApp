using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string City { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public Contact Contact { get; set; }
    }
}
