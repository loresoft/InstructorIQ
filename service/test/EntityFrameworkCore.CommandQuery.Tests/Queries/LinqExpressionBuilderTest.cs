using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Queries;
using FluentAssertions;
using Xunit;

namespace EntityFrameworkCore.CommandQuery.Tests.Queries
{
    public class LinqExpressionBuilderTest
    {
        [Fact]
        public void FilterNormal()
        {
            var entityFilter = new EntityFilter { Name = "Rank", Value = 7 };

            var builder = new LinqExpressionBuilder();
            builder.Build(entityFilter);

            builder.Expression.Should().NotBeEmpty();
            builder.Expression.Should().Be("Rank == @0");

            builder.Parameters.Count.Should().Be(1);
            builder.Parameters[0].Should().Be(7);
        }

        [Fact]
        public void FilterLogicalOr()
        {
            var entityFilter = new EntityFilter
            {
                Logic = "or",
                Filters = new List<EntityFilter>
                {
                    new EntityFilter{ Name = "Rank", Value = 7 },
                    new EntityFilter{ Name = "Name", Value = "Apple" }
                }
            };

            var builder = new LinqExpressionBuilder();
            builder.Build(entityFilter);

            builder.Expression.Should().NotBeEmpty();
            builder.Expression.Should().Be("(Rank == @0 or Name == @1)");

            builder.Parameters.Count.Should().Be(2);
            builder.Parameters[0].Should().Be(7);
            builder.Parameters[1].Should().Be("Apple");
        }

        [Fact]
        public void FilterLogicalAnd()
        {
            var entityFilter = new EntityFilter
            {
                Filters = new List<EntityFilter>
                {
                    new EntityFilter{ Name = "Rank", Value = 7 },
                    new EntityFilter{ Name = "Name", Value = "Blueberry" }
                }

            };

            var builder = new LinqExpressionBuilder();
            builder.Build(entityFilter);

            builder.Expression.Should().NotBeEmpty();
            builder.Expression.Should().Be("(Rank == @0 and Name == @1)");

            builder.Parameters.Count.Should().Be(2);
            builder.Parameters[0].Should().Be(7);
            builder.Parameters[1].Should().Be("Blueberry");
        }

        [Fact]
        public void FilterComplex()
        {
            var entityFilter = new EntityFilter
            {
                Filters = new List<EntityFilter>
                {
                    new EntityFilter{ Name = "Rank", Operator = ">", Value = 5 },
                    new EntityFilter
                    {
                        Logic = "or",
                        Filters = new List<EntityFilter>
                        {
                            new EntityFilter{ Name = "Name", Value = "Strawberry" },
                            new EntityFilter{ Name = "Name", Value = "Blueberry" }
                        }
                    }
                }
            };

            var builder = new LinqExpressionBuilder();
            builder.Build(entityFilter);

            builder.Expression.Should().NotBeEmpty();
            builder.Expression.Should().Be("(Rank > @0 and (Name == @1 or Name == @2))");

            builder.Parameters.Count.Should().Be(3);
            builder.Parameters[0].Should().Be(5);
            builder.Parameters[1].Should().Be("Strawberry");
            builder.Parameters[2].Should().Be("Blueberry");
        }

        [Fact]
        public void FilterContains()
        {
            var entityFilter = new EntityFilter
            {
                Name = "Name",
                Operator = "Contains",
                Value = "Berry"
            };
            var builder = new LinqExpressionBuilder();
            builder.Build(entityFilter);

            builder.Expression.Should().NotBeEmpty();
            builder.Expression.Should().Be("Name.Contains(@0)");

            builder.Parameters.Count.Should().Be(1);
            builder.Parameters[0].Should().Be("Berry");
        }

        [Fact]
        public void FilterNotContains()
        {
            var entityFilter = new EntityFilter
            {
                Name = "Name",
                Operator = "!Contains",
                Value = "Berry"
            };
            var builder = new LinqExpressionBuilder();
            builder.Build(entityFilter);

            builder.Expression.Should().NotBeEmpty();
            builder.Expression.Should().Be("!Name.Contains(@0)");

            builder.Parameters.Count.Should().Be(1);
            builder.Parameters[0].Should().Be("Berry");
        }
    }
}
