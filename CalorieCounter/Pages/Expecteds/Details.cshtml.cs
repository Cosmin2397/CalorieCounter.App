using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.Expecteds
{
    public class DetailsModel : PageModel
    {
        private readonly IExpectedService expectedService;

        public Expected Expected { get; set; } = new Expected();

        public DetailsModel(IExpectedService expectedService)
        {
            this.expectedService = expectedService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var expected = await expectedService.GetExpectedByUser(GetUser());
            if (expected == null)
            {
                return NotFound();
            }
            else
            {
                Expected = expected;
                return Page();
            }
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
