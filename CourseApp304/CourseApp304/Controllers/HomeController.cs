using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseApp304.Models;

namespace CourseApp304.Controllers
{
    public class HomeController : Controller
    {
        // Database Connection
        public DataContext context;
        
        public HomeController(DataContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Request
        [HttpGet]
        public IActionResult AddRequest()
        {
            return View();
        }

        // POST: Request
        [HttpPost]
        public IActionResult AddRequest(Request model)
        {
            context.Requests.Add(model);
            context.SaveChanges();
            return View("Thanks", model);
        }

        // GET: List
        public IActionResult List()
        {
            return View(context.Requests.OrderBy(i => i.Id));
        }
    }
}