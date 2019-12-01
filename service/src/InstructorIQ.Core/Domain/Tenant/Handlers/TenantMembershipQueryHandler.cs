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
                UserName = request.UserName
            };

            var roles = await DataContext.TenantUserRoles
                .AsNoTracking()
                .Where(q => q.TenantId == request.TenantId && q.UserName == request.UserName)
                .Select(q => q.RoleName)
                .ToListAsync(cancellationToken);

            if (roles.Count == 0)
                return membership;

            membership.IsMember = roles.Contains(Data.Constants.Role.MemberName);
            membership.IsAttendee = roles.Contains(Data.Constants.Role.AttendeeName);
            membership.IsInstructor = roles.Contains(Data.Constants.Role.InstructorName);
            membership.IsAdministrator = roles.Contains(Data.Constants.Role.AdministratorName);

            return membership;
        }
    }
}
