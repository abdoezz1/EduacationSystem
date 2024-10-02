using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_day1.Models;
using MVC_day1.ViewModel;

namespace MVC_day1.Controllers
{
    public class TraineeController : Controller
    {
        Intelligent db = new Intelligent();
        [Route("/Trainee")]
        public IActionResult GetAll()
        {
            var students = db.Trainees.ToList();
            return View(students);
        }
		[Route("/TraineeD/{id}")]
        public IActionResult Details(int id)
        {
            var trainees = db.Trainees.Where(t => t.Id == id)
                .Select(t => new TraineeViewModel
                {
                    Name = t.Name,
                    image = t.image,
                    Department = t.Departments.Name,
                    Courses = db.Crs_Results.Where(t => t.Trainee_id == id)
                    .Include(c => c.Course)
                    .Select(c => new CourseViewModelVM
                    {
                        CourseName = c.Course.Name,
                        minDegree = c.Course.MinDegree,
                        Grade = c.Degree,
                        color = c.Degree < c.Course.MinDegree ? "color:red;" : "color:green;"

                    })
                    .ToList(),
                })
                .FirstOrDefault();
            return View(trainees);
        }

        [HttpPost]
        public async Task<IActionResult> AddTraineeAsync(Trainee t)
        {
            if (ModelState.IsValid)
            {
                bool isUnique = await db.IsObjectUniqueAsync(t);
                if (isUnique)
                {
                    db.Trainees.Add(t);
                    await db.SaveChangesAsync();
                    return RedirectToAction("GetAll");
                }
                else 
                {
                    ModelState.AddModelError("", "This Trainee Already exists.");
                }
                
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View("InsertTrainee", t);
        }
		[Route("/TraineeA")]
		public IActionResult InsertTrainee()
        {
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View();
        }
		[Route("/TraineeU/{id}")]
		public IActionResult Update(int id)
        {
            var trainee = db.Trainees.Find(id);
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View(trainee);
        }
        [HttpPost]
		
		public IActionResult SaveUpdate(Trainee t)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Update(t);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View("update", t);
        }

        public IActionResult Delete(int id)
        {
            var trainee = db.Trainees.Find(id);
            db.Trainees.Remove(trainee);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll_results()
        {
            var students = db.Trainees.ToList();
            return View(students);
        }


    }
}
