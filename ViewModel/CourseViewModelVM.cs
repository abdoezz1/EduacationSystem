using MVC_day1.Models;

namespace MVC_day1.ViewModel
{
    public class CourseViewModelVM
    {
        public string? CourseName { get; set; }
        public double Grade { get; set; }
        public int minDegree { get; set; }
        public string color { get; set; }
        public string Department { get; set; }

        public List<TraineeViewModel> trainees { get; set; }=new List<TraineeViewModel>();
        public List<InstructorViewModelVM> instructors { get; set; } = new List<InstructorViewModelVM>();

    }
}
