using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bogus;

using FluentAssertions;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.Extensions.DependencyInjection;

using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests.Domain;

[Collection("DependencyInjectionCollection")]
public class TopicTest : DependencyInjectionBase
{
    public TopicTest(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
        : base(outputHelper, dependencyInjection)
    {
    }

    [Fact]
    public async Task FullTest()
    {
        var mediator = ServiceProvider.GetService<IMediator>();
        mediator.Should().NotBeNull();

        var mapper = ServiceProvider.GetService<IMapper>();
        mapper.Should().NotBeNull();

        // Create Entity
        var generator = new Faker<TopicCreateModel>()
            .RuleFor(p => p.Description, f => f.Lorem.Sentence());

        var createModel = generator.Generate();
        createModel.TenantId = Data.Constants.Tenant.Test;
        createModel.Title = "TEST";

        var createCommand = new EntityCreateCommand<TopicCreateModel, TopicReadModel>(MockPrincipal.Default, createModel);
        var createResult = await mediator.Send(createCommand);
        createResult.Should().NotBeNull();

        // Get Entity by Key
        var identifierQuery = new EntityIdentifierQuery<Guid, TopicReadModel>(MockPrincipal.Default, createResult.Id);
        var identifierResult = await mediator.Send(identifierQuery);
        identifierResult.Should().NotBeNull();
        identifierResult.Title.Should().Be(createModel.Title);

        // Query Entity
        var entityQuery = new EntityQuery
        {
            Sort = new List<EntitySort> { new EntitySort { Name = "Updated", Direction = "Descending" } },
            Filter = new EntityFilter { Name = "Title", Value = "TEST" }
        };
        var listQuery = new EntityPagedQuery<TopicReadModel>(MockPrincipal.Default, entityQuery);

        var listResult = await mediator.Send(listQuery);
        listResult.Should().NotBeNull();

        // Patch Entity
        var patchModel = new JsonPatchDocument<Topic>();
        patchModel.Operations.Add(new Operation<Topic>
        {
            op = "replace",
            path = "/Description",
            value = "Patch Update"
        });

        var patchCommand = new EntityPatchCommand<Guid, TopicReadModel>(MockPrincipal.Default, createResult.Id, patchModel);
        var patchResult = await mediator.Send(patchCommand);
        patchResult.Should().NotBeNull();
        patchResult.Description.Should().Be("Patch Update");

        // Update Entity
        var updateModel = mapper.Map<TopicUpdateModel>(patchResult);
        updateModel.Description = "Update Command";

        var updateCommand = new EntityUpdateCommand<Guid, TopicUpdateModel, TopicReadModel>(MockPrincipal.Default, createResult.Id, updateModel);
        var updateResult = await mediator.Send(updateCommand);
        updateResult.Should().NotBeNull();
        updateResult.Description.Should().Be("Update Command");

        // Delete Entity
        var deleteCommand = new EntityDeleteCommand<Guid, TopicReadModel>(MockPrincipal.Default, createResult.Id);
        var deleteResult = await mediator.Send(deleteCommand);
        deleteResult.Should().NotBeNull();
        deleteResult.Id.Should().Be(createResult.Id);
    }
}
