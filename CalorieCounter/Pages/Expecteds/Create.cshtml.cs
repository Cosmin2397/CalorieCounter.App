using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CalorieCounter.Models;

namespace CalorieCounter.Pages.Expecteds
{
    public class CreateModel : PageModel
    {
        private readonly IExpectedService expectedService;

        public CreateModel(IExpectedService expectedService)
        {
            this.expectedService = expectedService;
        }

        [BindProperty]
        public Expected Expected { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid  || Expected == null)
            {
                return Page();
            }

            await expectedService.AddExpected(Expected);

            return RedirectToPage("/FoodDashes/Create");

        }

        public string GetUser()
        {
            var user = User.Identity.Name;
            if (string.IsNullOrEmpty(user))
            {
                return string.Empty;
            }
            return user;
        }
    }
}
