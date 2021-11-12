using System;
using System.Threading.Tasks;
using AutoMapper;
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
    public class TenantTest : DependencyInjectionBase
    {
        public TenantTest(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
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
            var createModel = Generator.Default.Single<TenantCreateModel>();
            createModel.Slug = "Test" + DateTime.Now.Ticks;
            createModel.TimeZone = "Central Standard Time";

            var createCommand = new EntityCreateCommand<TenantCreateModel, TenantReadModel>(MockPrincipal.Default, createModel);
            var createResult = await mediator.Send(createCommand).ConfigureAwait(false);
            createResult.Should().NotBeNull();

            // Get Entity by Key
            var identifierQuery = new EntityIdentifierQuery<Guid, TenantReadModel>(MockPrincipal.Default, createResult.Id);
            var identifierResult = await mediator.Send(identifierQuery).ConfigureAwait(false);
            identifierResult.Should().NotBeNull();
            identifierResult.Name.Should().Be(createModel.Name);

            // Query Entity
            var entityQuery = new EntityQuery
            {
                Sort = new List<EntitySort> { new EntitySort { Name = "Updated", Direction = "Descending" } },
                Filter = new EntityFilter { Name = "Slug", Value = "TEST" }
            };
            var listQuery = new EntityPagedQuery<TenantReadModel>(MockPrincipal.Default, entityQuery);

            var listResult = await mediator.Send(listQuery).ConfigureAwait(false);
            listResult.Should().NotBeNull();

            // Patch Entity
            var patchModel = new JsonPatchDocument<Tenant>();
            patchModel.Operations.Add(new Operation<Tenant>
            {
                op = "replace",
                path = "/Description",
                value = "Patch Update"
            });

            var patchCommand = new EntityPatchCommand<Guid, TenantReadModel>(MockPrincipal.Default, createResult.Id, patchModel);
            var patchResult = await mediator.Send(patchCommand).ConfigureAwait(false);
            patchResult.Should().NotBeNull();
            patchResult.Description.Should().Be("Patch Update");

            // Update Entity
            var updateModel = mapper.Map<TenantUpdateModel>(patchResult);
            updateModel.Description = "Update Command";

            var updateCommand = new EntityUpdateCommand<Guid, TenantUpdateModel, TenantReadModel>(MockPrincipal.Default, createResult.Id, updateModel);
            var updateResult = await mediator.Send(updateCommand).ConfigureAwait(false);
            updateResult.Should().NotBeNull();
            updateResult.Description.Should().Be("Update Command");

            // Delete Entity
            var deleteCommand = new EntityDeleteCommand<Guid, TenantReadModel>(MockPrincipal.Default, createResult.Id);
            var deleteResult = await mediator.Send(deleteCommand).ConfigureAwait(false);
            deleteResult.Should().NotBeNull();
            deleteResult.Id.Should().Be(createResult.Id);
        }


        [Fact]
        public async Task CreateTenant()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var createModel = new TenantCreateModel
            {
                Slug = "Test" + DateTime.Now.Ticks,
                Name = "Test Department " + DateTime.Now.Ticks,
                Description = "Created from Unit Test",
                TimeZone = "Central Standard Time"
            };

            var command = new EntityCreateCommand<TenantCreateModel, TenantReadModel>(MockPrincipal.Default, createModel);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }

        [Fact]
        public async Task QueryList()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var query = new EntityQuery
            {
                Sort = new List<EntitySort> { new EntitySort { Name = "Updated", Direction = "Descending" } },
                Filter = new EntityFilter { Name = "Slug", Value = "TEST" }
            };
            var command = new EntityPagedQuery<TenantReadModel>(MockPrincipal.Default, query);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }
    }
}
