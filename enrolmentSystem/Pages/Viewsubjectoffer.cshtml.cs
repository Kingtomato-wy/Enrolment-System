using enrolmentSystem.Data;
using enrolmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace enrolmentSystem.Pages
{
    public class ViewsubjectofferModel : PageModel
    {
        private readonly AppDbContext _context;

        public ViewsubjectofferModel(AppDbContext context)
        {
            _context = context;
        }


        public List<subjectOffered> subjectOffereds { get; set; } = new();

        public void OnGet()
        {
            Loaddata();
        }

        public IActionResult OnPostDeleteOffered(int subjectoffer)
        {
            var offeredSubject = _context.SubjectsOffered
                .FirstOrDefault(so => so.subjectOfferedID == subjectoffer);

            if (offeredSubject != null)
            {
                _context.SubjectsOffered.Remove(offeredSubject);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }


        public void Loaddata()
        {
            subjectOffereds = _context.SubjectsOffered.ToList();
        }
    }
}
