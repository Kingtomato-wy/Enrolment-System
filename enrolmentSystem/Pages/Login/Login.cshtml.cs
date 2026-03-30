using enrolmentSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace enrolmentSystem.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> logger;
        private readonly AppDbContext context;

        public LoginModel(ILogger<LoginModel> logger, AppDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "ID number is required! ")]
        public string ID { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Password is required! ")]
        public string Password { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            HttpContext.Session.Clear();
        }

        public IActionResult OnPost()
        {
            // Check Admin table
            var admin = context.Admin.FirstOrDefault(a => a.adminID == ID && a.adminPassword == Password);
            if (admin != null)
            {
                HttpContext.Session.SetString("AdminID", ID);
                return RedirectToPage("/AdminDashboard");
            }

            // Check Student table
            var student = context.Student.FirstOrDefault(s => s.studentID == ID && s.studentPassword == Password);
            if (student != null)
            {
                HttpContext.Session.SetString("StudentID", ID);
                return RedirectToPage("/StudentDashboard");
            }

            //If ID or Password empty, do not print summary error message. 
            if (ID == null || Password == null)
            {
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = "Invalid ID or Password";
            }

            return Page();
        }
    }
}
