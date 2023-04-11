using System.Collections.Generic;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;

using MediatR;
using MediatR.CommandQuery.Queries;

using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Template;

public class IndexModel : EntityPagedModelBase<TemplateReadModel>
{
    public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
        Sort = nameof(TenantReadModel.Name);
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
                    Name = nameof(TemplateReadModel.Name),
                    Value = Query,
                    Operator = EntityFilterOperators.Contains
                },
                new EntityFilter
                {
                    Name = nameof(TemplateReadModel.Description),
                    Value = Query,
                    Operator = EntityFilterOperators.Contains
                }
            }
        };

        return filter;
    }
}
