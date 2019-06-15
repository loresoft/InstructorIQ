using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.History
{
    public class ViewModel : EntityIdentifierModelBase<TopicUpdateModel>
    {
        public ViewModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {


        }

        public IReadOnlyCollection<Core.Models.HistoryRecord> History { get; set; }

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

        public string ComputeUrl(Core.Models.HistoryRecord history)
        {
            if (history.Entity == "Session")
                return Url.Page("/topic/session/view", new { topicid = Id, tenant = TenantRoute, id = history.Key });

            if (history.Entity == "Topic" && history.PropertyName == "LessonPlan")
                return Url.Page("/topic/planning/view", new { id = Id, tenant = TenantRoute });

            return Url.Page("/topic/view", new { id = Id, tenant = TenantRoute });
        }
    }
}