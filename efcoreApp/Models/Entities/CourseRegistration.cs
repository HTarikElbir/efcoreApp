namespace efcoreApp.Models.Entities
{
    public class CourseRegistration
    {
        // Id is the primary key
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime RegistrationDate { get; set; }  
    }
}
