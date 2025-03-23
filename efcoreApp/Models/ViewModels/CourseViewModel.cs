using efcoreApp.Models.Entities;

namespace efcoreApp.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TeacherId { get; set; }
        public ICollection<CourseRegistration>? CourseRegistrations = new List<CourseRegistration>();

    }
}
