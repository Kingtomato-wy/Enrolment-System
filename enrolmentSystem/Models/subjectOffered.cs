using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enrolmentSystem.Models
{
    public class subjectOffered
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? subjectOfferedID { get; set; }

        [ForeignKey("Subject")]
        [Required]
        public string? subjectID { get; set; }
        public Subject? Subject { get; set; }

        [ForeignKey("Session")]
        public string? sessionID { get; set; }
        public Session? Session { get; set; }


        [ForeignKey("Lecturer")]
        [Required]
        public string? lecturerID { get; set; }
        public Lecturer? Lecturer { get; set; }
        [Required]
        public string section { get; set; } 
        [Required]
        [Range(10, 100, ErrorMessage = "Seats must be at least 10-100.")]
        public int maxSeats { get; set; }

        public ICollection<Timetable>? Timetables { get; set; }
        public ICollection<Evaluation>? Evaluations { get; set; }
        public Enrolment? Enrolment { get; set; }




    }
}
