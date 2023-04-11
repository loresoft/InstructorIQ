using System.Collections.Generic;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;

using MediatR;
using MediatR.CommandQuery.Queries;

using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Location;

public class IndexModel : EntityPagedModelBase<LocationReadModel>
{
    public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
    }

    protected override EntityFilter CreateFilter()
    {
        var filter = new EntityFilter
        {
            Logic = EntityFilterLogic.Or,
            Filters = new List<EntityFilter>
            {
                new EntityFilter
                {
                    Name = nameof(LocationReadModel.Name),
                    Value = Query,
                    Operator = EntityFilterOperators.Contains
                },
                new EntityFilter
                {
                    Name = nameof(LocationReadModel.Description),
                    Value = Query,
                    Operator = EntityFilterOperators.Contains
                },
                new EntityFilter
                {
                    Name = nameof(LocationReadModel.City),
                    Value = Query,
                    Operator = EntityFilterOperators.Contains
                }
            }
        };

        return filter;
    }

}
