using CourseApp304.Data.Abstract;
using CourseApp304.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Data.Concrete
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class
    {
        private DataContext context;
        public GenericRepository(DataContext _context)
        {
            context = _context;
        }

        public virtual void Delete(int id)
        {
            context.Remove<Tentity>(Get(id));
            context.SaveChanges();
        }

        public virtual Tentity Get(int id)
        {
            return context.Set<Tentity>().Find(id);
        }

        public virtual IEnumerable<Tentity> GetAll()
        {
            return context.Set<Tentity>().ToList();
        }

        

        public virtual void Insert(Tentity entity)
        {
            context.Add<Tentity>(entity);
            context.SaveChanges();
        }

        public virtual void Update(Tentity entity)
        {
            context.Update<Tentity>(entity);
            context.SaveChanges();
        }
    }
}
