using System;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Queries;
using FluentAssertions;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using MediatR;
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
        public async Task CreateGroup()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var createModel = new GroupCreateModel
            {
                Name = "Group " + DateTime.Now.Ticks,
                Description = "Created from Unit Test",
                OrganizationId = Data.Constants.Organization.Test
            };

            var command = new EntityCreateCommand<Group, GroupCreateModel, GroupReadModel>(createModel, MockPrincipal.Default);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

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
            var command = new EntityListQuery<Group, GroupReadModel>(query, MockPrincipal.Default);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }

    }
}
