using MVC_day1.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_day1.Validators
{
	public class UniqueDeptAttribute :ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
            Intelligent db = new Intelligent();
			var name = value as string;
			var dept = db.Departments.FirstOrDefault(x => x.Name == name);
			if (dept == null) 
			{
				return ValidationResult.Success;
			}
			return new ValidationResult("Department Already exists !!");
		}
	}
}
