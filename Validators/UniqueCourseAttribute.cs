using MVC_day1.Models;
using System.ComponentModel.DataAnnotations;


namespace MVC_day1.Validators
{
	public class UniqueCourseAttribute :ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) 
		{
            Intelligent db = new Intelligent();
			var name  = value as string;
			var course = db.Courses.FirstOrDefault(c => c.Name == name);
			if (course == null) 
			{
				return ValidationResult.Success;
			}
			return new ValidationResult("Department Already exists !");
		}
	}
}
