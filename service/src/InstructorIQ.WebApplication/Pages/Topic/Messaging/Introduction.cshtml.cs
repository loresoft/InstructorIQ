using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Messaging
{
    [Authorize(Policy = UserPolicies.InstructorPolicy)]
    public class IntroductionModel : EntityIdentifierModelBase<TopicUpdateModel>
    {
        private readonly IEmailTemplateService _templateService;
        private readonly UserClaimManager _userClaimManager;

        public IntroductionModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, IEmailTemplateService templateService, UserClaimManager userClaimManager) 
            : base(tenant, mediator, loggerFactory)
        {
            _templateService = templateService;
            _userClaimManager = userClaimManager;
        }

        [BindProperty]
        public TopicEmail Message { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();

            var address = _userClaimManager.GetEmail(User) ?? User.Identity.Name;
            var name = _userClaimManager.GetDisplayName(User);

            Message = new TopicEmail();
            Message.ReplyToAddress = address;
            Message.ReplyToName = name;

            return Page();
        }

    }
}