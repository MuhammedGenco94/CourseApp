using CourseApp304.Data.Abstract;
using CourseApp304.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Data.Concrete
{
    public class EfInstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private DataContext context;
        public EfInstructorRepository(DataContext _context) : base(_context)
        {
            context = _context;
        }

        public override IEnumerable<Instructor> GetAll()
        {
            //return context.Instructors.Include(i=>i.Courses);
            context.Courses.Where(x => x.Instructor != null && x.isActive).Load();
            return context.Instructors;
        }

        public IEnumerable<Instructor> GetTopInstructor()
        {
            throw new NotImplementedException();
        }
    }
}
