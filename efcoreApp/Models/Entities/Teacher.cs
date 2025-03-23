using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Models.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string FullName => $"{Name} {Surname}";
        public string?  Email { get; set; }
        public string? Phone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}