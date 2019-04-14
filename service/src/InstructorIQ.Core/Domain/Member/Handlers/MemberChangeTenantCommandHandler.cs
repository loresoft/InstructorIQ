using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Security;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberChangeTenantCommandHandler : DataContextHandlerBase<InstructorIQContext, MemberChangeTenantCommand, MemberReadModel>
    {
        private readonly UserClaimManager _claimManager;

        public MemberChangeTenantCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager claimManager) : base(loggerFactory, dataContext, mapper)
        {
            _claimManager = claimManager;
        }

        protected override async Task<MemberReadModel> Process(MemberChangeTenantCommand request, CancellationToken cancellationToken)
        {
            var userId = _claimManager.GetUserId(request.Principal);

            // get user
            var user = await DataContext.Users
                .FindAsync(new object[] { userId }, cancellationToken);

            user.LastTenantId = request.TenantId;

            await DataContext.SaveChangesAsync(cancellationToken);

            var result = Mapper.Map<MemberReadModel>(user);

            return result;
        }
    }
}
