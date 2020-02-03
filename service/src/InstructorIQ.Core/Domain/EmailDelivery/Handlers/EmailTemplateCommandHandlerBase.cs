using InstructorIQ.Core.Services;
using MediatR;
using MediatR.CommandQuery.Handlers;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public abstract class EmailTemplateCommandHandlerBase<TRequest, TResponse> : RequestHandlerBase<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected EmailTemplateCommandHandlerBase(ILoggerFactory loggerFactory, IMediator mediator, IEmailTemplateService emailTemplate)
            : base(loggerFactory)
        {
            Mediator = mediator;
            EmailTemplate = emailTemplate;
        }

        protected IMediator Mediator { get; }

        protected IEmailTemplateService EmailTemplate { get; }
    }
}