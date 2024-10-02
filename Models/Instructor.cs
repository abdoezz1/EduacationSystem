using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_day1.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

		[DisplayName("Instructor Name")]
		[MinLength(3, ErrorMessage = "Name must be More than 2 Chars")]
		[MaxLength(20, ErrorMessage = "Name must be less than 21 Chars")]
		public string Name { get; set; }

		[Range(5000, 15000, ErrorMessage = "Salary must be between 5000 and 15000")]
		[Required(ErrorMessage = "This Field is Required")]
		public int Salary  { get; set; }
		[Required(ErrorMessage = "This Field is Required")]
		public string Address { get; set; }
        public string? Image { get; set; }

        [ForeignKey("Departments")]
        [DisplayName("Department")]
        public int? Dept_id { get; set; }

        [ForeignKey("Courses")]
        [DisplayName("Course")]
        public int? Course_id { get; set; }

        
        public Department? Departments { get; set; }

        
        public Course? Courses { get; set; }
    }
}
