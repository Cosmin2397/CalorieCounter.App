using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/FoodDashes/Create");
        }
    }
}
