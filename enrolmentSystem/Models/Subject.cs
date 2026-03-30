using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Models
{
    public class Subject
    {
        [Key]
        [Required]
        public string subjectID { get; set; }

        [Required(ErrorMessage = "Subject Name is required! ")]
        public string subjectName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Subject Credit is required! ")]
        public int subjectCredit { get; set; }
        public ICollection<subjectOffered>? SubjectsOffered { get; set; }
        [ForeignKey("Course")]
        [Required]
        public string courseID { get; set; }
        public Course? Course { get; set; }

    }
}
