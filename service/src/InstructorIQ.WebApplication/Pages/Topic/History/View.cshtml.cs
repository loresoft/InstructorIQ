using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Audit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.History
{
    [ResponseCache(Duration = 300)]
    public class ViewModel : EntityIdentifierModelBase<TopicUpdateModel>
    {
        public ViewModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {


        }

        public IReadOnlyCollection<AuditRecord<Guid>> History { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            var topicTask = base.OnGetAsync();

            var query = new TopicHistoryQuery(User, Id);
            var historyTask = Mediator.Send(query);

            await Task.WhenAll(
                topicTask,
                historyTask
            );

            History = historyTask.Result;

            return Page();
        }

        public string ComputeUrl(AuditRecord<Guid> history)
        {
            if (history.Entity == "Session")
                return Url.Page("/topic/session/view", new { topicid = Id, tenant = TenantRoute, id = history.Key });
            if (history.Entity == "SessionInstructor")
                return Url.Page("/topic/session/index", new { id = Id, tenant = TenantRoute });
            if (history.Entity == "Discussion")
                return Url.Page("/topic/discussion/view", new { id = Id, tenant = TenantRoute });

            return Url.Page("/topic/view", new { id = Id, tenant = TenantRoute });
        }
    }
}