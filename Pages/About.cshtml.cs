using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using url_shortener.Context;

namespace url_shortener.Pages
{
    public class AboutModel : PageModel
    {
        [BindProperty]
        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        private readonly ApplicationContext _context;

        public AboutModel(ApplicationContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var about = _context.Description.FirstOrDefault();
            Description = about.Description;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var about = _context.Description.FirstOrDefault();
            about.Description = Description;
            _context.Description.Update(about);
            _context.SaveChanges();

            return RedirectToPage(); //refresh
        }
    }
}
