using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Models.Entities
{
    public class Course
    {
        // Id is the primary key
        public int Id { get; set; }

        [Display(Name = "Course Name")]
        public string? Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public ICollection<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();

    }
}
