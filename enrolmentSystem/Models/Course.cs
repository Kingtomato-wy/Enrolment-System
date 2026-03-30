using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Models
{
    public class Course
    {
        [Key]
        public string? courseID { get; set; }

        [Required(ErrorMessage = "Course Name is required! ")]
        public string? courseName { get; set; } = string.Empty;
        public ICollection<Student>? Students { get; set; }
        public ICollection<Subject>? Subjects { get; set; }

    }
}
