using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_day1.Models;

namespace MVC_day1.Controllers
{
    public class InstructorController : Controller
    {
        Intelligent db = new Intelligent();


        public IActionResult HomePage() 
        { return View(); }
		public IActionResult Contact()
		{ return View(); }

        [Route("/Ins")]

        public IActionResult GetAll()
        {
            var instructors = db.Instructors.ToList();
            return View(instructors);
        }
		[Route("/Ins/{id}")]
		public IActionResult Details(int id) 
        {
            var instructors = db.Instructors.Include(i => i.Departments).Include(i=>i.Courses).FirstOrDefault(i => i.Id == id);
                return View(instructors);
        }
        [HttpGet]
		[Route("/InsA")]
		public IActionResult InsertInstructor() 
        {
			var depts = db.Departments.ToList();
			ViewBag.Departments = depts;
            var courses = db.Courses.ToList();
            ViewBag.Courses = courses;  
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddInstructorAsync(Instructor ins) 
        {
            if (ModelState.IsValid) 
            {
                bool isUnique = await db.IsObjectUniqueAsync(ins);
                if (isUnique) 
                {
                    db.Instructors.Add(ins);
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetAll");
                }
                else
                {
                    ModelState.AddModelError("", "This Instructor Already Exists.");
                }
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            var courses = db.Courses.ToList();
            ViewBag.Courses = courses;
            return View("InsertInstructor");
        }

        public IActionResult Delete(int id) 
        {
            var ins = db.Instructors.Find(id);
            db.Instructors.Remove(ins);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
		[Route("/InsU/{id}")]
		public IActionResult Update(int id) 
        {
			var depts = db.Departments.ToList();
			ViewBag.Departments = depts;
            var courses = db.Courses.ToList();
            ViewBag.Courses = courses;
            var ins = db.Instructors.Find(id);
            return View(ins);
        }

        [HttpPost]
        public IActionResult SaveUpdate(Instructor ins) 
        {
            if (ModelState.IsValid) 
            {
                db.Instructors.Update(ins);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
			var depts = db.Departments.ToList();
			ViewBag.Departments = depts;
            var courses = db.Courses.ToList();
            ViewBag.Courses = courses;
            return View("Update", ins);
		}

    }
}
