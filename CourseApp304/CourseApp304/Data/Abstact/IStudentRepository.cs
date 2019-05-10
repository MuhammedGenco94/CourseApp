using CourseApp304.Data.Abstract;
using CourseApp304.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Data.Abstact
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        IEnumerable<Student> GetTopStudents();

    }
}
