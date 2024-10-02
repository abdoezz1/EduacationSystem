using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC_day1.Validators;

namespace MVC_day1.Models
{
    public class Department
    {
        [Key]
        public int Dept_id {  get; set; }
        [DisplayName("Department Name")]
        [Required]
        [UniqueDept]
        public string Name { get; set; }
		[Required]
		[DisplayName("Manager Name")]
		[MinLength(3, ErrorMessage = "Name must be More than 2 Chars")]
		[MaxLength(20, ErrorMessage = "Name must be less than 21 Chars")]
		public String? Manager { get; set; }

        public ICollection <Instructor>? Instructors { get; set; }
        public ICollection<Trainee>? Trainees { get; set; }
        public ICollection<Course>? Courses { get; set; } 
    }
}
