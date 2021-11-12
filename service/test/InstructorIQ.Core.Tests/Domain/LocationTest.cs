using System;
using System.Threading.Tasks;
using DataGenerator;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using FluentAssertions;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;

namespace InstructorIQ.Core.Tests.Domain
{
    [Collection("DependencyInjectionCollection")]
    public class LocationTest : DependencyInjectionBase
    {
        public LocationTest(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
            : base(outputHelper, dependencyInjection)
        {
        }

        [Fact]
        public async Task FullTest()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var createModel = new LocationCreateModel
            {
                Name = "Location " + DateTime.Now.Ticks,
                Description = "Created from Unit Test",
                TenantId = Data.Constants.Tenant.Test
            };

            var createCommand = new EntityCreateCommand<LocationCreateModel, LocationReadModel>(MockPrincipal.Default, createModel);
            var createResult = await mediator.Send(createCommand).ConfigureAwait(false);
            createResult.Should().NotBeNull();

            var identifierQuery = new EntityIdentifierQuery<Guid, LocationReadModel>(MockPrincipal.Default, createResult.Id);
            var identifierResult = await mediator.Send(identifierQuery).ConfigureAwait(false);
            identifierResult.Should().NotBeNull();
            identifierResult.Name.Should().Be(createModel.Name);


            var entityQuery = new EntityQuery
            {
                Sort = new List<EntitySort> { new EntitySort { Name = "Updated", Direction = "Descending" } },
                Filter = new EntityFilter { Name = "Name", Value = "Location", Operator = "StartsWith" }
            };
            var listQuery = new EntityPagedQuery<LocationReadModel>(MockPrincipal.Default, entityQuery);

            var listResult = await mediator.Send(listQuery).ConfigureAwait(false);
            listResult.Should().NotBeNull();

            var patchModel = new JsonPatchDocument<Location>();
            patchModel.Operations.Add(new Operation<Location>
            {
                op = "replace",
                path = "/Description",
                value = "Patch Update"
            });

            var patchCommand = new EntityPatchCommand<Guid, LocationReadModel>(MockPrincipal.Default, createResult.Id, patchModel);
            var patchResult = await mediator.Send(patchCommand).ConfigureAwait(false);
            patchResult.Should().NotBeNull();
            patchResult.Description.Should().Be("Patch Update");

            var updateModel = new LocationUpdateModel
            {
                Name = patchResult.Name,
                Description = "Update Command",
                TenantId = patchResult.TenantId,
                RowVersion = patchResult.RowVersion
            };

            var updateCommand = new EntityUpdateCommand<Guid, LocationUpdateModel, LocationReadModel>(MockPrincipal.Default, createResult.Id, updateModel);
            var updateResult = await mediator.Send(updateCommand).ConfigureAwait(false);
            updateResult.Should().NotBeNull();
            updateResult.Description.Should().Be("Update Command");

            var deleteCommand = new EntityDeleteCommand<Guid, LocationReadModel>(MockPrincipal.Default, createResult.Id);
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
                Sort = new List<EntitySort> { new EntitySort { Name = "Updated", Direction = "Descending" } },
                Filter = new EntityFilter { Name = "Name", Value = "Location", Operator = "StartsWith" }
            };
            var command = new EntityPagedQuery<LocationReadModel>(MockPrincipal.Default, query);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }

    }
}