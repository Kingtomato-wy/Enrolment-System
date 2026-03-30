using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enrolmentSystem.Models
{
    public class Timetable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int timetableID { get; set; }

        [ForeignKey("subjectOffered")]
        public int subjectOfferedID { get; set; }
        public subjectOffered? SubjectOffered { get; set; }

        [Required(ErrorMessage = "Day is required!")]
        public DayOfWeek day { get; set; }

        [Required(ErrorMessage = "Start Time is required!")]
        public TimeOnly startTime { get; set; }

        [Required(ErrorMessage = "End Time is required!")]
        public TimeOnly endTime { get; set; }

        [Required(ErrorMessage = "Room Type is required!")]
        public string roomtType { get; set; } 
    }
}
