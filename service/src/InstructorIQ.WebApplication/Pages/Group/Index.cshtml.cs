using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Group
{
    public class IndexModel : EntityListModelBase<GroupReadModel>
    {

        public IndexModel(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
            Sort = nameof(GroupReadModel.Sequence);
        }

        protected override EntityFilter CreateFilter()
        {
            var filter = new EntityFilter
            {
                Logic = EntityFilterLogic.Or,
                Filters = new[]
                {
                    new EntityFilter
                    {
                        Name = nameof(GroupReadModel.Name),
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    },
                    new EntityFilter
                    {
                        Name = nameof(GroupReadModel.Description),
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    }
                }
            };

            return filter;
        }
    }
}