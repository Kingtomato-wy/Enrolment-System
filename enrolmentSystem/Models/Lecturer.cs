using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Models
{
    public class Lecturer
    {
        [Key]
        public string? lecturerID { get; set; }

        [Required(ErrorMessage = "Name is required! ")]
        public string? lecturerName { get; set; } = string.Empty;
        public ICollection<subjectOffered>? SubjectsOffered { get; set; }

    }
}
