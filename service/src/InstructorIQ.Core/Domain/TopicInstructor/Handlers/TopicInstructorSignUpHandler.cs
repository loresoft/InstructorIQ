using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;

using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using MediatR.CommandQuery.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers;

public class TopicInstructorSignUpHandler : DataContextHandlerBase<InstructorIQContext, TopicInstructorSignUpCommand, CompleteModel>
{
    public TopicInstructorSignUpHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
        : base(loggerFactory, dataContext, mapper)
    {
    }

    protected override async Task<CompleteModel> Process(TopicInstructorSignUpCommand request, CancellationToken cancellationToken)
    {

        var identityName = request.Principal?.Identity?.Name;

        var existingTopics = await DataContext.TopicInstructors
            .Where(s => s.InstructorId == request.InstructorId)
            .ToListAsync(cancellationToken);

        var selectedTopicIds = request.Topics ?? new List<Guid>();

        AddInstructorTopics(existingTopics, selectedTopicIds, request.InstructorId, identityName);

        await DataContext.SaveChangesAsync(cancellationToken);

        return new CompleteModel();
    }

    private void AddInstructorTopics(List<TopicInstructor> existingTopics, List<Guid> selectedTopicIds, Guid instructorId, string username)
    {
        var existingTopicIds = existingTopics
            .Select(i => i.TopicId)
            .ToList();

        var insertTopicIds = selectedTopicIds
            .Except(existingTopicIds)
            .ToList();

        if (insertTopicIds.Count == 0)
            return;

        foreach (var topicId in insertTopicIds)
        {
            var topicInstructor = new TopicInstructor
            {
                TopicId = topicId,
                InstructorId = instructorId,
                Created = DateTimeOffset.UtcNow,
                CreatedBy = username,
                Updated = DateTimeOffset.UtcNow,
                UpdatedBy = username
            };

            DataContext.TopicInstructors.Add(topicInstructor);
        }
    }
}
