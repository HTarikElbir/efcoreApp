using efcoreApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        public int TeacherId { get; set; }

        public ICollection<CourseRegistration>? CourseRegistrations = new List<CourseRegistration>();

    }
}
