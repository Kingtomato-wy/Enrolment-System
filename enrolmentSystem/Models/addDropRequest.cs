using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enrolmentSystem.Models
{
    public class addDropRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? requestID { get; set; }

        [ForeignKey("Student")]
        public string? studentID { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("subjectOffered")]
        public int? subjectOfferedID { get; set; }
        public subjectOffered? subjectOffered { get; set; }

        [ForeignKey("Enrolment")]
        public int? enrolmentID { get; set; }
        public Enrolment? Enrolment { get; set; }

        [ForeignKey("Admin")]
        public string? adminID { get; set; }
        public Admin? Admin { get; set; }




        [Required(ErrorMessage = "This field is required! ")]
        public string? requestReason { get; set; } = string.Empty;

        public DateTime? requestDate { get; set; }

        public string? approvalStatus { get; set; } = string.Empty;
    }
}
