using System;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Queries;
using FluentAssertions;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests.Domain
{
    [Collection("DependencyInjectionCollection")]
    public class GroupTest : DependencyInjectionBase
    {
        public GroupTest(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
            : base(outputHelper, dependencyInjection)
        {
        }

        [Fact]
        public async Task FullTest()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var createModel = new GroupCreateModel
            {
                Name = "Group " + DateTime.Now.Ticks,
                Description = "Created from Unit Test",
                OrganizationId = Data.Constants.Organization.Test
            };

            var createCommand = new EntityCreateCommand<GroupCreateModel, GroupReadModel>(createModel, MockPrincipal.Default);
            var createResult = await mediator.Send(createCommand).ConfigureAwait(false);
            createResult.Should().NotBeNull();

            var identifierQuery = new EntityIdentifierQuery<Guid, GroupReadModel>(createResult.Id, MockPrincipal.Default);
            var identifierResult = await mediator.Send(identifierQuery).ConfigureAwait(false);
            identifierResult.Should().NotBeNull();
            identifierResult.Name.Should().Be(createModel.Name);


            var entityQuery = new EntityQuery
            {
                Sort = new[] { new EntitySort { Name = "Updated", Direction = "Descending" } },
                Filter = new EntityFilter { Name = "Name", Value = "Group", Operator = "StartsWith" }
            };
            var listQuery = new EntityListQuery<GroupReadModel>(entityQuery, MockPrincipal.Default);

            var listResult = await mediator.Send(listQuery).ConfigureAwait(false);
            listResult.Should().NotBeNull();

            var patchModel = new JsonPatchDocument<Group>();
            patchModel.Operations.Add(new Operation<Group>
            {
                op = "replace",
                path = "/Description",
                value = "Patch Update"
            });

            var patchCommand = new EntityPatchCommand<Guid, GroupReadModel>(createResult.Id, patchModel, MockPrincipal.Default);
            var patchResult = await mediator.Send(patchCommand).ConfigureAwait(false);
            patchResult.Should().NotBeNull();
            patchResult.Description.Should().Be("Patch Update");

            var updateModel = new GroupUpdateModel
            {
                Name = patchResult.Name,
                Description = "Update Command",
                OrganizationId = patchResult.OrganizationId,
                RowVersion = patchResult.RowVersion
            };

            var updateCommand = new EntityUpdateCommand<Guid, GroupUpdateModel, GroupReadModel>(createResult.Id, updateModel, MockPrincipal.Default);
            var updateResult = await mediator.Send(updateCommand).ConfigureAwait(false);
            updateResult.Should().NotBeNull();
            updateResult.Description.Should().Be("Update Command");

            var deleteCommand = new EntityDeleteCommand<Guid, GroupReadModel>(createResult.Id, MockPrincipal.Default);
            var deleteResult = await mediator.Send(deleteCommand).ConfigureAwait(false);
            deleteResult.Should().NotBeNull();
            deleteResult.Id.Should().Be(createResult.Id);
        }

        [Fact]
        public async Task QueryStartsWithList()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var query = new EntityQuery
            {
                Sort = new[] { new EntitySort { Name = "Updated", Direction = "Descending" } },
                Filter = new EntityFilter { Name = "Name", Value = "Group", Operator = "StartsWith" }
            };
            var command = new EntityListQuery<GroupReadModel>(query, MockPrincipal.Default);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }

    }
}
