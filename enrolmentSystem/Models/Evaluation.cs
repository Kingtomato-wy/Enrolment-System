using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Models
{
    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? EvaluationID { get; set; }

        [ForeignKey("Student")]
        public string? StudentID { get; set; }
        public Student? Student { get; set; }
        public string Comment { get; set; } = string.Empty;

        [Range(1, 5, ErrorMessage = "Rank must be between 1 and 5.")]
        public int Rank { get; set; }

        [ForeignKey("SubjectOffered")]
        public int? SubjectOfferedID { get; set; }
        public subjectOffered? SubjectOffered { get; set; }
    }
}
