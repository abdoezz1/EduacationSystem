using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_day1.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }

		[DisplayName("Trainee Name")]
		[MinLength(3, ErrorMessage = "Name must be More than 2 Chars")]
		[MaxLength(20, ErrorMessage = "Name must be less than 21 Chars")]
		public string Name { get; set; }
        public string? image { get; set; } 
        [Required(ErrorMessage ="This Field is Required")]
        public string Address { get; set; }
        public int? Grade { get; set; }

        [ForeignKey("Departments")]

        [DisplayName("Department")]
        public int? Dept_id { get; set; }

        
        public Department? Departments { get; set; }

        public ICollection<Crs_result>? Crs_Results { get; set; } 
    }
}
