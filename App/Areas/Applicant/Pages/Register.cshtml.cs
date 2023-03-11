using App.Data;
using App.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace App.Areas.Applicant.Pages
{
    public class RegisterModel : PageModel
    {
        //This is what we want to use in terms of depedencies
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RegisterModel> _logger;

        //These are the form binding properties
        [BindProperty]
        [MinLength(2)]
        [MaxLength(255)]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [BindProperty]
        [MaxLength(255)]
        [Display(Name = "Address 2")]
        public string? Address2 { get; set; }

        [BindProperty]
        [MinLength(2)]
        [MaxLength(255)]
        [Display(Name = "Address 3")]
        public string Address3 { get; set; }

        [BindProperty]
        [MinLength(3)]
        [MaxLength(10)]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [BindProperty]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [BindProperty]
        [MinLength(2)]
        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [BindProperty]
        [MinLength(2)]
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string SecondName { get; set; }

        //This is how we can do dependency injection
        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //This method gets called when the user goes on the register page
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        //This method gets called when the user click on the submit button on the form
        public async Task<IActionResult> OnPostSubmitAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Application application = new Application()
                {
                    Address1 = Address1,
                    Address2 = Address2,
                    Address3 = Address3,
                    Postcode = Postcode,
                    Date = DateOfBirth,
                    FirstName = FirstName,
                    SecondName = SecondName
                };

                await _context.Applications.AddAsync(application);

                await _context.SaveChangesAsync();

                return RedirectToPage("Success");
            }
            catch (Exception ex)
            {
                return RedirectToPage("Failed");
            }
        }
    }
}
