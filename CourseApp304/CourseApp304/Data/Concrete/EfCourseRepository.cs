using CourseApp304.Data.Abstract;
using CourseApp304.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Data.Concrete
{
    public class EfCourseRepository : ICourseRepository
    {
        private DataContext context;

        public EfCourseRepository(DataContext _context)
        {
            context = _context;
        }

        public IQueryable<Course> Courses => context.Courses;

        public int CreateCourse(Course newCourse)
        {
            context.Courses.Add(newCourse);
            context.SaveChanges();
            return newCourse.Id;
        }

        public void DeleteCourse(int courseid)
        {
            context.Courses.Remove(new Course() { Id = courseid });
            context.SaveChanges();
        }

        

        public Course GetById(int courseid)
        {
            return context.Courses
                .Include(x=>x.Instructor)
                .ThenInclude(x=>x.Contact)
                .ThenInclude(x=>x.Address)
                .FirstOrDefault(x=>x.Id==courseid);
            
        }

        public IEnumerable<Course> GetCourseByFilter(string name = null, decimal? price = null, string isActive = null,string instructorName=null)
        {
            IQueryable<Course> query = context.Courses
                .Include(x=>x.Instructor);      //Instructor u include etmek gerekiyor yoksa nesne tanımıyor
            if (name != null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }
            if (price != null)
            {
                query = query.Where(x => x.Price <= price);
            }
            if (isActive=="on")
            {
                query = query.Where(x => x.isActive == true);
            }
            if (instructorName != null)
            {
                query = query.Where(x => x.Instructor.Name.ToLower().Contains(instructorName.ToLower()));
            }
            return query.ToList();
        }

        

        public IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByActive(bool isActive)
        {
            return context.Courses.Where(x => x.isActive == isActive).ToList();
        }

        public void UpdateAll(int Id, Course[] courses)
        {
            context.Courses.UpdateRange(courses.Where(x => x.InstructorId != Id));
            context.SaveChanges();
        }

        public void UpdateCourse(Course updateCourse, Course originalCourse = null)
        {
            if (originalCourse == null)
            {
                originalCourse = context.Courses.Find(updateCourse.Id);
            }
            else
            {
                context.Courses.Attach(originalCourse);
            }

            originalCourse.Name = updateCourse.Name;
            originalCourse.Description = updateCourse.Description;
            originalCourse.Price = updateCourse.Price;
            originalCourse.isActive = updateCourse.isActive;
            originalCourse.Instructor.Name = updateCourse.Instructor.Name;
            originalCourse.Instructor.Contact.Email = updateCourse.Instructor.Contact.Email;
            originalCourse.Instructor.Contact.Phone = updateCourse.Instructor.Contact.Phone;
            originalCourse.Instructor.Contact.Address.City = updateCourse.Instructor.Contact.Address.City;
            originalCourse.Instructor.Contact.Address.Country = updateCourse.Instructor.Contact.Address.Country;
            originalCourse.Instructor.Contact.Address.Text = updateCourse.Instructor.Contact.Address.Text;
            
            EntityEntry entry = context.Entry(originalCourse);
            EntityEntry entry1 = context.Entry(originalCourse.Instructor);
            EntityEntry entry2 = context.Entry(originalCourse.Instructor.Contact);
            EntityEntry entry3 = context.Entry(originalCourse.Instructor.Contact.Address);
            


            //Modified,Unchanged,Added,Deleted,Detached

            Console.WriteLine($"EntityState:{entry.State}");
            foreach(var property in new string[] { "Name", "Description", "Price", "isActive" })
            {
                Console.WriteLine($"{property} - old:{entry.OriginalValues[property]} new:{entry.CurrentValues[property]}");
            }
            Console.WriteLine($"EntityState:{entry1.State}");
            foreach (var property in new string[] { "Name" })
            {
                Console.WriteLine($"{property} - old:{entry1.OriginalValues[property]} new:{entry1.CurrentValues[property]}");
            }
            Console.WriteLine($"EntityState:{entry2.State}");
            foreach (var property in new string[] { "Email", "Phone" })
            {
                Console.WriteLine($"{property} - old:{entry2.OriginalValues[property]} new:{entry2.CurrentValues[property]}");
            }
            Console.WriteLine($"EntityState:{entry3.State}");
            foreach (var property in new string[] { "Country", "City", "Text" })
            {
                Console.WriteLine($"{property} - old:{entry3.OriginalValues[property]} new:{entry3.CurrentValues[property]}");
            }
            context.SaveChanges();
        }
    }
}
