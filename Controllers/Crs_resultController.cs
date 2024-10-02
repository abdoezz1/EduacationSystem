using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_day1.Models;
using System.Diagnostics;

namespace MVC_day1.Controllers
{
	public class Crs_resultController : Controller
	{
        Intelligent db = new Intelligent();

		public IActionResult InsertResult()
		{
			var trainees = db.Trainees.ToList();
			var courses = db.Courses.ToList();
			ViewBag.Trainees = trainees;
			ViewBag.Courses = courses;
			return View();
		}
		[HttpPost]
		public IActionResult AddResult(Crs_result res)
		{
			if (ModelState.IsValid)
			{
				db.Crs_Results.Add(res);
				db.SaveChanges();
				return RedirectToAction("GetAll", "Trainee");
			}
			var trainees = db.Trainees.ToList();
			var courses = db.Courses.ToList();
			ViewBag.Trainees = trainees;
			ViewBag.Courses = courses;
			return View("InsertResult", res);
		}







		public IActionResult Update(string name)
		{
			var courses = db.Courses.ToList();
			ViewBag.Courses = courses;
			var trainees = db.Trainees.ToList();
			ViewBag.Trainees = trainees;
			var result = db.Crs_Results.Find(name);
			return View(result);
		}

		public IActionResult SaveUpdate(Crs_result crs)
		{
			if (ModelState.IsValid)
			{
				db.Crs_Results.Update(crs);
				db.SaveChanges();
				return RedirectToAction("GetResults", "Department");
			}
			var courses = db.Courses.ToList();
			ViewBag.Courses = courses;
			var trainees = db.Trainees.ToList();
			ViewBag.Trainees = trainees;
			return View("Update", crs);

		}
	}
}
