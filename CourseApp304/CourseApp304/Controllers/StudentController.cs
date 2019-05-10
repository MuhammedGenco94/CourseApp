using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp304.Data.Abstact;
using CourseApp304.Data.Abstract;
using CourseApp304.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp304.Controllers
{
    public class StudentController : Controller
    {
        //private DataContext context;
        //public StudentController(DataContext _context)
        //{
        //    context = _context;
        //}

        private IGenericRepository<Student> repository;
        private IStudentRepository repo;


        public StudentController(IGenericRepository<Student> _repository,IStudentRepository _repo)
        {
            repository = _repository;
            repo = _repo;
        }

        public IActionResult Index()
        {

            return View(repo.GetTopStudents());
        }

        public IActionResult Create()
        {
            return View("StudentEditor");
        }
        public IActionResult Edit(int id)
        {

            return View("StudentEditor", repo.GetTopStudents().FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Student entity)
        {
            if (entity.Id==0)
            {
                //repository.Students.Add(entity);
                repository.Insert(entity);
            }
            else
            {
                //repository.Students.Update(entity);
                repository.Update(entity);
            }
            //repository.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}