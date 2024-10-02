using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC_day1.Models
{
    public class CourseResult
    {
        [Key]
        public int Id { get; set; }
        public int Grade { get; set; }

        [ForeignKey("Course")]
        public int? Course_id { get; set; }

        [ForeignKey("Trainees")]
        public int? Trainee_id { get; set; }

        [DisplayName("Course Name")]
        public Course? Course { get; set; }

        public Trainee? Trainees { get; set; }
    }
}
