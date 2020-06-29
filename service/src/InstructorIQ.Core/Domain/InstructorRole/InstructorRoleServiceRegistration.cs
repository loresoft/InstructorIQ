using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain
{
    public class InstructorRoleServiceRegistration : DomainServiceRegistrationBase
    {
         public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, InstructorIQ.Core.Data.Entities.InstructorRole, InstructorRoleReadModel>(services);

            RegisterEntityCommand<Guid, InstructorIQ.Core.Data.Entities.InstructorRole, InstructorRoleReadModel, InstructorRoleCreateModel, InstructorRoleUpdateModel>(services);
        }

    }
}
