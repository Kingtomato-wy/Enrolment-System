using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Models
{
    public class Session
    {
        [Key]
        [Required]
        public string sessionID { get; set; }
        [Required]
        public DateOnly startDate { get; set; }
        [Required]
        public DateOnly endDate { get; set; }
        [Required]
        public string sessionStatus { get; set; } 
        public ICollection<subjectOffered>? SubjectsOffered { get; set; }

    }
}
