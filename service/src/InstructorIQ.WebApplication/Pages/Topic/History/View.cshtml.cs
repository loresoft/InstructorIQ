﻿using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.History
{
    public class ViewModel : EntityIdentifierModelBase<TopicUpdateModel>
    {
        public ViewModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }
    }
}