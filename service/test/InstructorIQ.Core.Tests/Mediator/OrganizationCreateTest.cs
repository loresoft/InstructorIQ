using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataGenerator;
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
    public class OrganizationCreateTest : DependencyInjectionBase
    {
        public OrganizationCreateTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {

        }

        [Fact]
        public async Task CreateOrganization()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var createModel = new OrganizationCreateModel
            {
                Abbreviation = "TEST",
                Name = "Test Department " + DateTime.Now.Ticks,
                Description = "Created from Unit Test"
            };

            var command = new EntityCreateCommand<Organization, OrganizationCreateModel, OrganizationReadModel>(createModel, MockPrincipal.Default);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }

        [Fact]
        public async Task QueryList()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var command = new EntityListQuery<Organization, OrganizationReadModel>
            {
                Sort = new[] { new EntitySort { Name = "Updated", Direction = "Descending" } },
                Filter = new EntityFilter { Name = "Abbreviation", Value = "TEST" }
            };

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }
    }
}
