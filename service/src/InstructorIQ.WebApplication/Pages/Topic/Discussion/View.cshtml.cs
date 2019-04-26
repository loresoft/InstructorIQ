using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Discussion
{
    public class ViewModel : MediatorModelBase
    {
        private readonly UserClaimManager _userClaimManager;

        public ViewModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserClaimManager userClaimManager)
            : base(tenant, mediator, loggerFactory)
        {
            _userClaimManager = userClaimManager;

        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        [BindProperty]
        public string Message { get; set; }

        public string DisplayName => _userClaimManager.GetDisplayName(User) ?? User.Identity?.Name;

        public TopicReadModel Topic { get; set; }

        public IReadOnlyCollection<DiscussionReadModel> Items { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var loadTopicTask = LoadTopic();
            var discussionsTask = LoadDiscussions();

            // load all in parallel
            await Task.WhenAll(
                loadTopicTask,
                discussionsTask
            );

            Topic = loadTopicTask.Result;

            Items = discussionsTask.Result
                .OrderBy(r => r.MessageDate)
                .ToList();

            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var createModel = new DiscussionCreateModel
            {
                TopicId = Id,
                TenantId = Tenant.Value.Id,
                DisplayName = _userClaimManager.GetDisplayName(User),
                EmailAddress = _userClaimManager.GetUserName(User),
                MessageDate = DateTimeOffset.UtcNow,
                Message = Message
            };

            var userAgent = Request.UserAgent();
            Mapper.Map(userAgent, createModel);

            var command = new EntityCreateCommand<DiscussionCreateModel, DiscussionReadModel>(User, createModel);
            var result = await Mediator.Send(command);

            return RedirectToPage("/topic/discussion/view", new { id = Id, tenant = TenantRoute });
        }


        private async Task<TopicReadModel> LoadTopic()
        {
            var command = new EntityIdentifierQuery<Guid, TopicReadModel>(User, Id);
            var result = await Mediator.Send(command);

            return result;
        }

        private async Task<IReadOnlyCollection<DiscussionReadModel>> LoadDiscussions()
        {
            var query = new DiscussionTopicQuery(User, Id);
            var result = await Mediator.Send(query);

            return result;
        }

    }
}