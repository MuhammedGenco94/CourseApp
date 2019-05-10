using CourseApp304.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Data.Abstract
{
    public interface IInstructorRepository:IGenericRepository<Instructor>
    {
        IEnumerable<Instructor> GetTopInstructor();

        //Instructor Get(int id);
        //IEnumerable<Instructor> GetAll();
        //void Delete(int id);
        //void Update(Instructor entity);
        //void Insert(Instructor entity);

    }
}
