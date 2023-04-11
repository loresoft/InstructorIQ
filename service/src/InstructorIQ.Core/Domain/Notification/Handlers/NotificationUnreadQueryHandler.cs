using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR.CommandQuery.EntityFrameworkCore.Handlers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers;

public class NotificationUnreadQueryHandler : DataContextHandlerBase<InstructorIQContext, NotificationUnreadQuery, NotificationUnreadModel>
{
    public NotificationUnreadQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper) : base(loggerFactory, dataContext, mapper)
    {
    }

    protected override async Task<NotificationUnreadModel> Process(NotificationUnreadQuery request, CancellationToken cancellationToken)
    {
        var count = await DataContext.Notifications
            .AsTracking()
            .Where(n => n.TenantId == request.TenantId && n.UserName == request.UserName && n.Read == null)
            .CountAsync(cancellationToken);

        var model = new NotificationUnreadModel { Count = count };

        return model;
    }
}
