using CalorieCounter.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login Login { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(Login.Email, Login.Password, Login.RememberMe, false);
                if(result.Succeeded)
                {
                        return RedirectToPage("/FoodDashes/Create");

                }

                ModelState.AddModelError(string.Empty, "UserName or Password incorrect;");
            }

            return Page();
        }
    }
}
