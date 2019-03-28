using System.Globalization;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    public class ViewModel : EntityIdentifierModelBase<TopicReadModel>
    {
        public ViewModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        public string MonthName => Entity.TargetMonth.HasValue
            ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Entity.TargetMonth.Value)
            : string.Empty;
    }
}