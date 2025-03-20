namespace efcoreApp.Models.Entities
{
    public class CourseRegistration
    {
        // Id is the primary key
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!; 
        public DateTime RegistrationDate { get; set; }  
    }
}
