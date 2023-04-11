using System;
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

public class TenantMembershipCommandHandler : DataContextHandlerBase<InstructorIQContext, TenantMembershipCommand, TenantMembershipModel>
{
    public TenantMembershipCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
        : base(loggerFactory, dataContext, mapper)
    {
    }

    protected override async Task<TenantMembershipModel> Process(TenantMembershipCommand request, CancellationToken cancellationToken)
    {
        var membership = request.Membership;
        var tenantId = membership.TenantId;
        var userId = membership.UserId;

        var roles = await DataContext.TenantUserRoles
            .Where(q => q.TenantId == membership.TenantId && q.UserId == membership.UserId)
            .ToListAsync(cancellationToken);

        // remove all to reset
        foreach (var role in roles)
            DataContext.TenantUserRoles.Remove(role);

        if (membership.IsMember)
            AddRole(tenantId, userId, Data.Constants.Role.Member);

        if (membership.IsAttendee)
            AddRole(tenantId, userId, Data.Constants.Role.Attendee);

        if (membership.IsInstructor)
            AddRole(tenantId, userId, Data.Constants.Role.Instructor);

        if (membership.IsAdministrator)
            AddRole(tenantId, userId, Data.Constants.Role.Administrator);

        await DataContext.SaveChangesAsync(cancellationToken);

        return membership;
    }

    private void AddRole(Guid tenantId, Guid userId, Guid roleId)
    {
        var entity = new Data.Entities.TenantUserRole
        {
            TenantId = tenantId,
            UserId = userId,
            RoleId = roleId
        };
        DataContext.TenantUserRoles.Add(entity);
    }
}
