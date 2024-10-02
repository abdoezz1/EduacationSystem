using MVC_day1.Models;

namespace MVC_day1.ViewModel
{
    public class DeptViewModelVM
    {
        public string ?Name { get; set; }
        public string ?Manager { get; set; }
        public List<InstructorViewModelVM> Instructor {  get; set; } = new List<InstructorViewModelVM>();
        public List<string> Trainee_Name { get; set; } = new List<string>();
        public List<string> Course_Name { get; set; } = new List<string>();
		public List<CourseViewModelVM> Course { get; set; } = new List<CourseViewModelVM>();

	}
}
