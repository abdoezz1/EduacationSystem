using Microsoft.EntityFrameworkCore;
using MVC_day1.Validators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_day1.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Course Name")]
        [Required]
        [UniqueCourse]
        public string? Name { get; set; }
        public int Degree { get; set; }

        [Range(50,60,ErrorMessage ="Min Degree is between 50 and 60") ]
        public int MinDegree { get; set; }

        [ForeignKey("Departments")]
        [DisplayName("Department")]
        public int? Dept_id {  get; set; }

        public ICollection<Crs_result>? Crs_Results { get;set; }
        public ICollection<Instructor>? Instructors { get; set; }
        
        public Department? Departments { get; set; }
        
    }
}
