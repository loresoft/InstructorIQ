using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;

using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.User;

[Authorize]
public class NotificationModel : EntityPagedModelBase<NotificationReadModel>
{
    public NotificationModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
        Sort = $"{nameof(NotificationReadModel.Created)}:desc";
    }

    public async Task<IActionResult> OnPostMarkRead(Guid notificationId, bool read)
    {
        if (read)
            return RedirectToPage("/user/notification");

        var patchModel = new JsonPatchDocument();
        patchModel.Operations.Add(new Operation
        {
            op = "replace",
            path = $"/{nameof(NotificationReadModel.Read)}",
            value = DateTimeOffset.UtcNow
        });
        var updateCommand = new EntityPatchCommand<Guid, NotificationReadModel>(User, notificationId, patchModel);
        var result = await Mediator.Send(updateCommand);

        return RedirectToPage("/user/notification");
    }

    protected override EntityQuery CreateQuery()
    {
        var query = new EntityQuery(null, PageNumber, PageSize, Sort);
        query.Filter = CreateFilter();

        return query;
    }

    protected override EntityFilter CreateFilter()
    {
        var filters = new List<EntityFilter>
        {
            new EntityFilter
            {
                Name = nameof(NotificationReadModel.UserName),
                Value = User.Identity.Name,
                Operator = EntityFilterOperators.Equal
            }
        };

        var filter = new EntityFilter
        {
            Logic = EntityFilterLogic.And,
            Filters = filters
        };

        if (string.IsNullOrWhiteSpace(Query))
            return filter;

        filters.Add(new EntityFilter
        {
            Name = nameof(NotificationReadModel.Message),
            Value = Query,
            Operator = EntityFilterOperators.Contains
        });

        return filter;
    }
}
