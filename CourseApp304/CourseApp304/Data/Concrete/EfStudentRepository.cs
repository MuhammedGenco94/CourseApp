using CourseApp304.Data.Abstact;
using CourseApp304.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Data.Concrete
{
    public class EfStudentRepository : IStudentRepository
    {
        private DataContext context;
        public EfStudentRepository(DataContext _context)
        {
            context = _context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetTopStudents()
        {
            return context.Students.Include(x => x.Address).ToList();
        }

        public void Insert(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
