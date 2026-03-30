using enrolmentSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Pages.Login
{
    public class ForgotPasswordModel : PageModel
    {
		private readonly AppDbContext context;
		public ForgotPasswordModel(AppDbContext context)
		{
			this.context = context;
		}

		[BindProperty]
		[Required(ErrorMessage = "ID number is required! ")]
		public string ID { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string? ErrorMessage { get; set; } = string.Empty;

		public void OnGet()
        {
        }

		public IActionResult OnPost()
		{
			// Check Admin table
			var admin = context.Admin.FirstOrDefault(a => a.adminID == ID);
			if (admin != null)
			{
				Email = admin.adminEmail;
			}

			// Check Student table
			var student = context.Student.FirstOrDefault(s => s.studentID == ID);
			if (student != null)
			{
				Email = student.studentEmail;
			}

			/*
			if (ID == null)
			{
				ErrorMessage = "User ID is required";
			}
			else
			{
				ErrorMessage = "User ID not found! ";
			}
			*/

			return Page();
		}
	}
}
