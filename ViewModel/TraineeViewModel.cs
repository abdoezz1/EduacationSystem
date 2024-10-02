namespace MVC_day1.ViewModel
{
    public class TraineeViewModel
    {
        public string? Name { get; set; }

        public string? Department { get; set; }
        public string? image { get; set; }

        public List<CourseViewModelVM> Courses { get; set; } = [];
    }
}
