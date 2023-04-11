using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR.CommandQuery.EntityFrameworkCore.Handlers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers;

public class MemberUserNameQueryHandler
    : DataContextHandlerBase<InstructorIQContext, MemberUserNameQuery, MemberReadModel>
{
    public MemberUserNameQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
        : base(loggerFactory, dataContext, mapper)
    {
    }

    protected override async Task<MemberReadModel> Process(MemberUserNameQuery request, CancellationToken cancellationToken)
    {
        var result = await DataContext.Users
            .AsNoTracking()
            .Where(u => u.UserName == request.UserName)
            .ProjectTo<MemberReadModel>(Mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

        return result;
    }
}
