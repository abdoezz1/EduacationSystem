using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_day1.Models
{
    public class Crs_result
    {
        [Key]
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Course")]
        [DisplayName("Course Name")]
        public int? Course_id { get; set; }

        [ForeignKey("Trainees")]
        [DisplayName("Trainee Name")]
        public int? Trainee_id { get; set; }

        
        public Course? Course { get; set; }

        public Trainee? Trainees { get; set; }
    }
}
