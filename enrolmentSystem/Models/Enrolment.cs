using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace enrolmentSystem.Models
{
    public class Enrolment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? enrolmentID { get; set; }

        [ForeignKey("Student")]
        public string? studentID { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("subjectOffered")]
        public int? subjectOfferedID { get; set; }
        public subjectOffered? SubjectOffered { get; set; }

        public string? status { get; set; } = string.Empty;

        public DateTime? enrolDate { get; set; }

        [ForeignKey("Payment")]
        public int? paymentID { get; set; }
        public Payment? Payment { get; set; }

    }
}
