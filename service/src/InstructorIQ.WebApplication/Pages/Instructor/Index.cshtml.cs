using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Instructor
{
    public class IndexModel : EntityListModelBase<InstructorReadModel>
    {
        public IndexModel(IMediator mediator, ILoggerFactory loggerFactory) : base(mediator, loggerFactory)
        {
            Sort = nameof(InstructorReadModel.FamilyName);
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
                        Name = nameof(InstructorReadModel.GivenName),
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    },
                    new EntityFilter
                    {
                        Name = nameof(InstructorReadModel.FamilyName),
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    },
                    new EntityFilter
                    {
                        Name = nameof(InstructorReadModel.EmailAddress),
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    }
                }
            };

            return filter;
        }
    }
}