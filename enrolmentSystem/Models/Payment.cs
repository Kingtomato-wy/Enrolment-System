using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enrolmentSystem.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? paymentID { get; set; }

        [ForeignKey("Enrolment")]
        public int? enrolmenttID { get; set; }
        public ICollection<Enrolment>? Enrolments { get; set; } = new List<Enrolment>();

        public DateTime? paymentDate { get; set; }

        public string? paymentStatus { get; set; } = string.Empty;

        [Required(ErrorMessage = "Payment Method is required! ")]
        public string? paymentMethod { get; set; } = string.Empty;
    }
}
