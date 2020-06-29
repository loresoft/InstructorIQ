using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace InstructorIQ.WebApplication.Pages.SignUp
{
    [Authorize(Policy = UserPolicies.UserPolicy)]
    public class ViewModel : EntityIdentifierModelBase<SignUpUpdateModel>
    {
        private readonly UserManager<Core.Data.Entities.User> _userManager;

        public ViewModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserManager<Core.Data.Entities.User> userManager)
            : base(tenant, mediator, loggerFactory)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public List<Guid> Selected { get; set; }

        public List<SignUpTopicReadModel> SignUpTopics { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();

            SignUpTopics = await LoadSignUpTopics();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Selected.Count == 0)
            {
                SignUpTopics = await LoadSignUpTopics();
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            var command = new TopicInstructorSignUpCommand(User, user.Id, Selected);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully saved instructor signups");

            return RedirectToPage("/signup/View", new { id = Id, tenant = TenantRoute });
        }

        public async Task<IActionResult> OnPostDeleteInstructorSignUp(Guid topicInstructorId)
        {
            var command = new EntityDeleteCommand<Guid, TopicInstructorReadModel>(User, topicInstructorId);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully deleted instructor signup");

            return RedirectToPage("/signup/View", new { id = Id, tenant = TenantRoute });
        }

        private async Task<List<SignUpTopicReadModel>> LoadSignUpTopics()
        {
            var filter = new EntityFilter
            {
                Name = nameof(SignUpTopicReadModel.SignUpId),
                Value = Id,
                Operator = EntityFilterOperators.Equal
            };
            var select = new EntitySelect(filter);
            var command = new EntitySelectQuery<SignUpTopicReadModel>(User, select);
            var result = await Mediator.Send(command);

            return result
                .OrderBy(p => p.TopicCalendarYear)
                .ThenBy(p => p.TopicTargetMonth)
                .ThenBy(p => p.TopicTitle)
                .ToList();
        }

    }
}