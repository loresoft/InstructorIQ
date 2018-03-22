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
    public class TopicTest : DependencyInjectionBase
    {
        public TopicTest(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
            : base(outputHelper, dependencyInjection)
        {
        }

        [Fact]
        public async Task CreateTopic()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var createModel = new TopicCreateModel
            {
                Title = "Topic " + DateTime.Now.Ticks,
                Description = "Created from Unit Test",
                OrganizationId = Data.Constants.Organization.Test
            };

            var command = new EntityCreateCommand<Topic, TopicCreateModel, TopicReadModel>(createModel, MockPrincipal.Default);

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
                Sort = new[] { new EntitySort { Name = "Updated", Direction = "Descending" } },
                Filter = new EntityFilter { Name = "Title", Value = "Topic", Operator = "StartsWith" }
            };
            var command = new EntityListQuery<Topic, TopicReadModel>(query, MockPrincipal.Default);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();
        }

    }
}