using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstructorIQ.WebApplication.Pages.Account;

[AllowAnonymous]
public class ForgotPasswordConfirmationModel : PageModel
{
    public void OnGet()
    {

    }
}
