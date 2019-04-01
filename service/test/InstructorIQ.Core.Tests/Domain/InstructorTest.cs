using System;
using System.Threading.Tasks;
using AutoMapper;
using DataGenerator;
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
    public class InstructorTest : DependencyInjectionBase
    {
        public InstructorTest(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
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
            var createModel = Generator.Default.Single<InstructorCreateModel>();
            createModel.TenantId = Data.Constants.Tenant.Test;
            createModel.DisplayName = $"{createModel.GivenName} {createModel.FamilyName}";
            createModel.JobTitle = "TEST";

            var createCommand = new EntityCreateCommand<InstructorCreateModel, InstructorReadModel>(createModel, MockPrincipal.Default);
            var createResult = await mediator.Send(createCommand).ConfigureAwait(false);
            createResult.Should().NotBeNull();

            // Get Entity by Key
            var identifierQuery = new EntityIdentifierQuery<Guid, InstructorReadModel>(createResult.Id, MockPrincipal.Default);
            var identifierResult = await mediator.Send(identifierQuery).ConfigureAwait(false);
            identifierResult.Should().NotBeNull();
            identifierResult.DisplayName.Should().Be(createModel.DisplayName);

            // Query Entity
            var entityQuery = new EntityQuery
            {
                Sort = new[] { new EntitySort { Name = "Updated", Direction = "Descending" } },
                Filter = new EntityFilter { Name = "JobTitle", Value = "TEST" }
            };
            var listQuery = new EntityPagedQuery<InstructorReadModel>(entityQuery, MockPrincipal.Default);

            var listResult = await mediator.Send(listQuery).ConfigureAwait(false);
            listResult.Should().NotBeNull();

            // Patch Entity
            var patchModel = new JsonPatchDocument<Instructor>();
            patchModel.Operations.Add(new Operation<Instructor>
            {
                op = "replace",
                path = "/DisplayName",
                value = "Patch Update"
            });

            var patchCommand = new EntityPatchCommand<Guid, InstructorReadModel>(createResult.Id, patchModel, MockPrincipal.Default);
            var patchResult = await mediator.Send(patchCommand).ConfigureAwait(false);
            patchResult.Should().NotBeNull();
            patchResult.DisplayName.Should().Be("Patch Update");

            // Update Entity
            var updateModel = mapper.Map<InstructorUpdateModel>(patchResult);
            updateModel.DisplayName = "Update Command";

            var updateCommand = new EntityUpdateCommand<Guid, InstructorUpdateModel, InstructorReadModel>(createResult.Id, updateModel, MockPrincipal.Default);
            var updateResult = await mediator.Send(updateCommand).ConfigureAwait(false);
            updateResult.Should().NotBeNull();
            updateResult.DisplayName.Should().Be("Update Command");

            // Delete Entity
            var deleteCommand = new EntityDeleteCommand<Guid, InstructorReadModel>(createResult.Id, MockPrincipal.Default);
            var deleteResult = await mediator.Send(deleteCommand).ConfigureAwait(false);
            deleteResult.Should().NotBeNull();
            deleteResult.Id.Should().Be(createResult.Id);
        }
    }
}