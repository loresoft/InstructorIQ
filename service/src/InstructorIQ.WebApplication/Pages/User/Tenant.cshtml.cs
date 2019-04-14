using System;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.User
{
    [Authorize]
    public class TenantModel : EntityPagedModelBase<TenantReadModel>
    {
        private readonly SignInManager<Core.Data.Entities.User> _signInManager;
        private readonly UserManager<Core.Data.Entities.User> _userManager;

        public TenantModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, SignInManager<Core.Data.Entities.User> signInManager, UserManager<Core.Data.Entities.User> userManager) 
            : base(tenant, mediator, loggerFactory)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public override async Task<IActionResult> OnGetAsync()
        {
            var query = CreateQuery();
            var command = new TenantPagedQuery(User, query);

            var result = await Mediator.Send<TenantPagedResult>(command);
            Total = result.Total;
            Items = result.Data;

            return Page();
        }

        public async Task<IActionResult> OnPostChangeTenant(Guid tenantId)
        {
            var command = new MemberChangeTenantCommand(User, tenantId);
            var result = await Mediator.Send(command);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            await _signInManager.RefreshSignInAsync(user);
            
            return RedirectToPage("/Index");
        }

        protected override EntityFilter CreateFilter()
        {
            var filter = new EntityFilter
            {
                Logic = EntityFilterLogic.Or,
                Filters = new[]
                {
                    new EntityFilter
                    {
                        Name = nameof(TenantReadModel.Name),
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    },
                    new EntityFilter
                    {
                        Name = nameof(TenantReadModel.Description),
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    }
                }
            };

            return filter;
        }
    }
}