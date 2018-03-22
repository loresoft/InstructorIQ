using System;
using System.Threading.Tasks;
using FluentAssertions;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Mediator.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests.Mediator
{
    [Collection("DependencyInjectionCollection")]
    public class LocationTest : DependencyInjectionBase
    {
        public LocationTest(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
            : base(outputHelper, dependencyInjection)
        {
        }

        [Fact]
        public async Task CreateLocation()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var createModel = new LocationCreateModel
            {
                Name = "Location " + DateTime.Now.Ticks,
                Description = "Created from Unit Test",
                OrganizationId = Data.Constants.Organization.Test
            };

            var command = new EntityCreateCommand<Location, LocationCreateModel, LocationReadModel>(createModel, MockPrincipal.Default);

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
                Filter = new EntityFilter { Name = "Name", Value = "Location", Operator = "StartsWith" }
            };
            var command = new EntityListQuery<Location, LocationReadModel>(query, MockPrincipal.Default);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }

    }
}