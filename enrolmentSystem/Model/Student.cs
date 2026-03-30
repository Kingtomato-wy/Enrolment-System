using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace enrolmentSystem.Model
{
	public class Student
	{
		[Key]
		public string? studentID { get; set; }

        [ForeignKey("Course")]
        public string? courseID { get; set; }
		public Course Course { get; set; }

        [Required(ErrorMessage = "Email Address is required! ")]
		[EmailAddress(ErrorMessage = "Invalid email address format")]
		public string? studentEmail { get; set; } = string.Empty;

		[Required(ErrorMessage = "Password is required!")]
		[DataType(DataType.Password)]
		public string? studentPassword { get; set; } = string.Empty;


		//Student Profile
		[Required(ErrorMessage = "Student Name is required! ")]
		public string? studentName { get; set; } = string.Empty;


		//Email
		[Required(ErrorMessage = "Primary Email Address is required! ")]
		[EmailAddress(ErrorMessage = "Invalid email address format")]
		public string? primaryEmail { get; set; } = string.Empty;

		[Required(ErrorMessage = "Aleternative Email Address is required! ")]
		[EmailAddress(ErrorMessage = "Invalid email address format")]
		public string? alternativeEmail { get; set; } = string.Empty;


		//Contact Number
		[Required(ErrorMessage = "Telephone Number is required! ")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Invalid Contact Number! ")]
        [RegularExpression(@"^\+\d{9,14}$", ErrorMessage = "Invalid Contact Number! ")]
		public string? TelNum { get; set; } = string.Empty;

		[Required(ErrorMessage = "HP Number is required! ")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Invalid Contact Number! ")]
        [RegularExpression(@"^\+\d{9,14}$", ErrorMessage = "Invalid Contact Number! ")]
		public string? HPNum { get; set; } = string.Empty;


		//Permanant Home Address
		[Required(ErrorMessage = "Address is required! ")]
		public string? permanantAddress { get; set; } = string.Empty;

		[Required(ErrorMessage = "Postal Code is required! ")]
		[RegularExpression(@"^\d{5}$", ErrorMessage = "Postal Code must be exactly 5 digits. ")]
		public int? permanantPostalCode { get; set; }

		[Required(ErrorMessage = "Area is required! ")]
		public string? permanantArea { get; set; } = string.Empty;

		[Required(ErrorMessage = "State is required! ")]
		public string? permanantState { get; set; } = string.Empty;

		[Required(ErrorMessage = "Country is required! ")]
		public string? permanantCountry { get; set; } = string.Empty;


		//Current Mailing Address
		[Required(ErrorMessage = "Address is required! ")]
		public string? currentAddress { get; set; } = string.Empty;

		[Required(ErrorMessage = "Postal Code is required! ")]
		[RegularExpression(@"^\d{5}$", ErrorMessage = "Postal Code must be exactly 5 digits. ")]
		public int? currentPostalCode { get; set; }

		[Required(ErrorMessage = "Area is required! ")]
		public string? currentArea { get; set; } = string.Empty;

		[Required(ErrorMessage = "State is required! ")]
		public string? currentState { get; set; } = string.Empty;

		[Required(ErrorMessage = "Country is required! ")]
		public string? currentCountry { get; set; } = string.Empty;


		//Emergency Contact
		[Required(ErrorMessage = "Relationship is required! ")]
		public string? emergencyContactRelationship { get; set; } = string.Empty;

		[Required(ErrorMessage = "Contact Person Name is required!")]
		[MinLength(3, ErrorMessage = "Contact Person Name must be at least 3 characters long")]
		public string? emergencyContactName { get; set; } = string.Empty;

		[Required(ErrorMessage = "HP Number is required! ")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Invalid Contact Number! ")]
        [RegularExpression(@"^\+\d{9,14}$", ErrorMessage = "Invalid Contact Number! ")]
		public string? emergencyHPNum { get; set; } = string.Empty;


		//Bank Details
		[Required(ErrorMessage = "Bank Name is required! ")]
		public string? bankName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Account Number is required! ")]
		public int? bankAccountNumber { get; set; }

		[Required(ErrorMessage = "Holder Name is required! ")]
		public string? bankHolderName { get; set; } = string.Empty;
	}
}
