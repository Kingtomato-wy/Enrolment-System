using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using enrolmentSystem.Data;
using enrolmentSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace enrolmentSystem.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {
        private readonly AppDbContext context;

        public ChangePasswordModel(AppDbContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public Student students { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Current Password is required! ")]
        public string currentPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "New Password is required! ")]
        [RegularExpression(@"^(?=.*\d)(?=.*[\W_]).{8,20}$", ErrorMessage = "Password must be 8-20 characters long, include at least one digit, and one special character.")]
        public string newPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Confirm Password is required! ")]
        public string confirmPassword { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Change to session later
            string StudentID = "I22023292";
            //string StudentId = HttpContext.Session.GetString("StudentID");

            //Check database student record
            var studentRecord = await context.Student.FirstOrDefaultAsync(s => s.studentID == StudentID);
            if (studentRecord == null)
            {
                ModelState.AddModelError("", "User not found.");
                return RedirectToPage("Login");
            }

            //Check Password
            if (currentPassword != studentRecord.studentPassword)
            {
                ErrorMessage = "Invalid Current Password! ";
                return Page();
            }

            //Check New Password and Confirm Password
            if (newPassword != confirmPassword)
            {
                ErrorMessage = "New Password is not same as Confirm Password! ";
                return Page();
            }

            studentRecord.studentPassword = newPassword;
            await context.SaveChangesAsync();

            return RedirectToPage("/StudentDashboard");
        }
    }
}