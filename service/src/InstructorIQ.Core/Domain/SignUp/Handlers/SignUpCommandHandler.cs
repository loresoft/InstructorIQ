using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using MediatR.CommandQuery.Models;
using MediatR.CommandQuery.Queries;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers
{
    public class SignUpCommandHandler : DataContextHandlerBase<InstructorIQContext, SignUpCommand, CompleteModel>
    {
        private readonly IMediator _mediator;

        public SignUpCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, IMediator mediator)
            : base(loggerFactory, dataContext, mapper)
        {
            _mediator = mediator;
        }

        protected override async Task<CompleteModel> Process(SignUpCommand request, CancellationToken cancellationToken)
        {
            var principal = request.Principal;

            var updateCommand = new EntityUpsertCommand<Guid, SignUpUpdateModel, SignUpReadModel>(principal, request.Id, request.InstructorSignUp);
            var updateModel = await _mediator.Send(updateCommand, cancellationToken);

            foreach (var signupTopic in request.InstructorSignUpTopics)
            {
                var signupTopicCommand = new EntityUpsertCommand<Guid, SignUpTopicUpdateModel, SignUpTopicReadModel>(principal, signupTopic.Id, signupTopic);
                var signupTopicModel = await _mediator.Send(signupTopicCommand, cancellationToken);

                var topicId = signupTopicModel.TopicId;

                var topicReadCommand = new EntityIdentifierQuery<Guid, TopicUpdateModel>(principal, topicId);
                var topicModel = await _mediator.Send(topicReadCommand, cancellationToken);

                topicModel.InstructorSlots = signupTopic.TopicInstructorSlots;

                var topicUpdateCommand = new EntityUpdateCommand<Guid, TopicUpdateModel, TopicReadModel>(principal, topicId, topicModel);
                var updatedModel = await _mediator.Send(topicUpdateCommand, cancellationToken);
            }

            return new CompleteModel();
        }
    }
}
