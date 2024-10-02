using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_day1.Models;
using MVC_day1.ViewModel;

namespace MVC_day1.Controllers
{
    public class CourseController : Controller
    {
        Intelligent db = new Intelligent();

        [Route("/Courses")]
        public IActionResult GetAll()
        {
            var courses = db.Courses.ToList();
            return View(courses);
        }

        [Route("/Courses/{id}")]
        public IActionResult Details(int id)
        {
            var courses = db.Courses
                .Where(c => c.Id == id)
                .Include(c => c.Instructors)
                .Select(c => new CourseViewModelVM
                {
                    CourseName = c.Name,
                    Department = c.Departments.Name,
                    minDegree = c.MinDegree,
                    instructors = db.Instructors
                    .Where(i => i.Course_id == id)
                    .Select(i => new InstructorViewModelVM
                    {
                        Name = i.Name,
                        Address = i.Address,
                        image = i.Image
                    })
                    .ToList(),
                    trainees = db.Crs_Results
                    .Where(t => t.Course_id == id)
                    .Include(t => t.Trainees)
                    .Select(t => new TraineeViewModel
                    {
                        Name = t.Trainees.Name
                    })
                    .ToList(),
                })
                .FirstOrDefault();
            return View(courses);
        }

      
        public IActionResult Delete(int id)
        {
            var course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        [Route("/CourseA")]
        public IActionResult InsertCourse()
        {
            var Depts = db.Departments.ToList();
            ViewBag.Departments = Depts;
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var Depts = db.Departments.ToList();
            ViewBag.Departments = Depts;
            return View("InsertCourse", course);
        }

        [Route("/CourseU/{id}")]
        public IActionResult Update(int id)
        {
            var course = db.Courses.Find(id);
            var Depts = db.Departments.ToList();
            ViewBag.Departments = Depts;
            return View(course);
        }

        public IActionResult SaveUpdate(Course c)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Update(c);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var Depts = db.Departments.ToList();
            ViewBag.Departments = Depts;
            return View("Update", c);
        }
    }
}
