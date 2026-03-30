using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Model
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? paymentID { get; set; }

        [ForeignKey("Enrolment")]
        public int? enrolmentID { get; set; }

        [ForeignKey("Course")]
        public string? courseID { get; set; }

        [ForeignKey("Receipt")]
        public int? receiptID { get; set; }

        [ForeignKey("Particular")]
        public int? particularID { get; set; }

        //public ICollection<Enrolment>? Enrolments { get; set; } = new List<Enrolment>();

        public DateTime? paymentDate { get; set; }

        public string? paymentStatus { get; set; } = string.Empty;

        [Required(ErrorMessage = "Payment Method is required! ")]
        public string? paymentMethod { get; set; } = string.Empty;
    }
}
