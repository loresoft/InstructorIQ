using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class InstructorServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Instructor, InstructorReadModel>(services);
            RegisterEntityCommand<Guid, Instructor, InstructorReadModel, InstructorCreateModel, InstructorUpdateModel>(services);
        }
    }
}