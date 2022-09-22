using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.Expecteds
{
    public class EditModel : PageModel
    {
        private readonly IExpectedService expectedService;

        public EditModel(IExpectedService expectedService)
        {
            this.expectedService = expectedService;
        }

        [BindProperty]
        public Expected Expected { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Expected = await this.expectedService.GetExpectedById(id);
            if (Expected == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Expected expected)
        {
            await expectedService.UpdateExpected(expected);

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
