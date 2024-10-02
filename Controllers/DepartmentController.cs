using Microsoft.AspNetCore.Mvc;
using MVC_day1.Models;
using MVC_day1.ViewModel;
using System.Runtime.Intrinsics.Arm;
namespace MVC_day1.Controllers
{
    public class DepartmentController : Controller
    {
        Intelligent db = new Intelligent();

        [Route("/Depts")]
        public IActionResult GetAll()
        {
            var depts = db.Departments.ToList();
            return View(depts);
        }
		[Route("/Depts/{id}")]
		public IActionResult Details(int id)
        {
            var dept = db.Departments
                .Where(d => d.Dept_id == id)
                .Select(d => new DeptViewModelVM
                {
                    Name = d.Name,
                    Manager = d.Manager,
                    Instructor = db.Instructors.Where(i => i.Dept_id == id).Select(i => new InstructorViewModelVM { Name = i.Name, Address = i.Address }).ToList(),
                    Trainee_Name = db.Trainees.Where(i => i.Dept_id == id).Select(i => i.Name).ToList(),
                    Course_Name = db.Courses.Where(i => i.Dept_id == id).Select(i => i.Name).ToList(),

                })
                .FirstOrDefault();
            return View(dept);
        }
		[Route("/DeptsA")]
		public IActionResult InsertDept()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Department dept)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(dept);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("InsertDept", dept);
        }
		[Route("/DeptsU/{id}")]
		public IActionResult Update(int id)
        {
            var dept = db.Departments.Find(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult SaveUpdate(Department dept)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Update(dept);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("Update", dept);
        }
        public IActionResult Delete(int id)
        {
            var dept = db.Departments.Find(id);
            var course = db.Courses.Where(c => c.Dept_id == id).ToList(); 
            var ins = db.Instructors.Where(i => i.Dept_id == id).FirstOrDefault();
            var trainee = db.Trainees.Where(t => t.Dept_id == id).ToList();

            foreach (var item in trainee)
            {
                if (trainee != null)
                {
                    foreach (var C in course)
                    {
                        if (course != null)
                        {
                            var crs = db.Crs_Results.Where(c => c.Trainee_id == item.Id && c.Course_id == C.Id).FirstOrDefault();
                            db.Crs_Results.Remove(crs);
                            db.Trainees.Remove(item);
                            db.Courses.Remove(C);
                        }
                        else
                        {
                            var crs = db.Crs_Results.Where(c => c.Trainee_id == item.Id).FirstOrDefault();
                            db.Crs_Results.Remove(crs);
                            db.Trainees.Remove(item);
                        }
                    }
                   
                }
            }
           
            if( ins != null )
            {
                db.Instructors.Remove(ins);
            }

            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        //public IActionResult GetResults(int id)
        //{
        //    var dept = db.Departments
        //        .Where(d => d.Dept_id == id)
        //        .Select(d => new DeptViewModelVM
        //        { 
        //            Course = ed.Courses.Where(c=>c.Dept_id == id).Select(c=> new CourseViewModelVM 
        //            {
        //                CourseName = c.
        //            }).ToList(),
        //        })
        //        .FirstOrDefault();
        //    return View(dept);
        //}
    }
}
