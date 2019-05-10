using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp304.Data.Abstract;
using CourseApp304.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp304.Controllers
{
    public class InstructorController : Controller
    {
        private IInstructorRepository repository;
        private ICourseRepository courseRepository;

        public InstructorController(IInstructorRepository _repository, ICourseRepository _courseRepository)
        {
            repository = _repository;
            courseRepository = _courseRepository;
        }

        public IActionResult Index()
        {
            ViewBag.InstructorEditId = TempData["InstructorEditId"];
            ViewBag.InstructorCreateId = TempData["InstructorCreateId"];
            ViewBag.InstructorChangeId = TempData["InstructorChangeId"];
            return View(repository.GetAll());
        }
        public IActionResult Edit(int id)
        {
            TempData["InstructorEditId"] = id;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Instructor entity)
        {
            repository.Update(entity);
            return RedirectToAction("Index");
        }


        public ActionResult Create(int id)
        {
            TempData["InstructorCreateId"] = id;
            return RedirectToAction("Index");
        }


        public IActionResult Change(int id)
        {
            TempData["InstructorChangeId"] = id;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Change(int Id, Course[] courses)
        {
            courseRepository.UpdateAll(Id, courses);
            return RedirectToAction("Index");
        }
    }
}