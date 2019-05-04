using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Account
{
    public class LinkModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<Core.Data.Entities.User> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LinkModel(IMediator mediator, SignInManager<Core.Data.Entities.User> signInManager, ILogger<LoginModel> logger)
        {
            _mediator = mediator;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(Token))
                return RedirectToPage("/Account/Login");

            var validateCommand = new LinkTokenValidateCommand(User, Token);
            var linkToken = await _mediator.Send(validateCommand);
            if (linkToken == null)
                return Page();

            var userManager = _signInManager.UserManager;
            var user = await userManager.FindByNameAsync(linkToken.UserName);
            if (user == null)
                return Page();

            await UpdateTenant(user, linkToken);
            
            await _signInManager.SignInAsync(user, true);

            _logger.LogInformation("User '{userName}' logged in with link.", user.UserName);

            return LocalRedirect(linkToken.Url ?? "/");
        }

        private async Task UpdateTenant(Core.Data.Entities.User user, LinkTokenReadModel linkToken)
        {
            if (!linkToken.TenantId.HasValue)
                return;

            if (user.LastTenantId == linkToken.TenantId)
                return;

            var userManager = _signInManager.UserManager;

            // change tenant id
            user.LastTenantId = linkToken.TenantId;
            var identityResult = await userManager.UpdateAsync(user);

            if (!identityResult.Succeeded)
                throw new InvalidOperationException($"Unexpected error occurred updating user '{linkToken.UserName}'.");
        }
    }
}