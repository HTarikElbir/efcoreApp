namespace efcoreApp.Models.Entities
{
    public class Student
    {
        // Id is the primary key
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? FullName => $"{Name} {SurName}";
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }
}
