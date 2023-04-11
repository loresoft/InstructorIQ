using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Security;

using MediatR.CommandQuery.EntityFrameworkCore.Handlers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers;

public class TemplateDropdownQueryHandler : DataContextHandlerBase<InstructorIQContext, TemplateDropdownQuery, IReadOnlyCollection<TemplateDropdownModel>>
{
    private readonly UserClaimManager _userClaimManager;

    public TemplateDropdownQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager)
        : base(loggerFactory, dataContext, mapper)
    {
        _userClaimManager = userClaimManager;
    }

    protected override async Task<IReadOnlyCollection<TemplateDropdownModel>> Process(TemplateDropdownQuery request, CancellationToken cancellationToken)
    {
        var tenantId = _userClaimManager.GetRequiredTenantId(request.Principal);

        var query = DataContext.Templates
            .AsNoTracking()
            .Where(q => q.TenantId == tenantId);

        if (request.TemplateType.HasValue())
            query = query.Where(q => q.TemplateType == request.TemplateType);

        var result = await query
            .OrderBy(q => q.Name)
            .ProjectTo<TemplateDropdownModel>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
