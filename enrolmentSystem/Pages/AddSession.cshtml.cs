using enrolmentSystem.Data;
using enrolmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace enrolmentSystem.Pages
{
    public class AddSessionModel : PageModel
    {

        private readonly AppDbContext _context;

        public AddSessionModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Session> sessionslist { get; set; } = new();

        [BindProperty]

        public Session session { get; set; }


        public void OnGet()
        {
            Loaddata();
        }

        public IActionResult OnPostAddsession()
        {

            // Check existence directly from database
            bool sessionExists = _context.Sessions.Any(s => s.sessionID == session.sessionID);
            // Add validation errors
            if (sessionExists)
                ModelState.AddModelError("session.sessionID", "Session ID already exists");
            if (!ModelState.IsValid)
            {
                Loaddata();
                return Page();
            }

            // Add the new session to the database
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return RedirectToPage("AddSession");
        }


        public void Loaddata()
        {
            sessionslist = _context.Sessions
            .OrderByDescending(s => s.startDate)
            .ThenByDescending(s => s.endDate)
            .ToList();

        }
    }
}
