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
namespace InstructorIQ.Core.Domain.Handlers
{
    public class TenantMembershipQueryHandler : DataContextHandlerBase<InstructorIQContext, TenantMembershipQuery, TenantMembershipModel>
    {
        public TenantMembershipQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<TenantMembershipModel> Process(TenantMembershipQuery request, CancellationToken cancellationToken)
        {
            var membership = new TenantMembershipModel
            {
                TenantId = request.TenantId,
                UserId = request.UserId
            };

            var roles = await DataContext.TenantUserRoles
                .AsNoTracking()
                .Where(q => q.TenantId == request.TenantId && q.UserId == request.UserId)
                .Select(q => q.RoleId)
                .ToListAsync(cancellationToken);

            if (roles.Count == 0)
                return membership;

            membership.IsMember = roles.Contains(Data.Constants.Role.Member);
            membership.IsAttendee = roles.Contains(Data.Constants.Role.Attendee);
            membership.IsInstructor = roles.Contains(Data.Constants.Role.Instructor);
            membership.IsAdministrator = roles.Contains(Data.Constants.Role.Administrator);

            return membership;
        }
    }
}
