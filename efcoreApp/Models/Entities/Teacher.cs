namespace efcoreApp.Models.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string?  Email { get; set; }
        public string? Phone { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
