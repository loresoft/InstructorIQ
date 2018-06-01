using System;
using System.Collections.Generic;
using FluentValidation;
using KickStart.Services;

namespace InstructorIQ.Core.Domain
{
    public class ValidationServiceModule : IServiceModule
    {
        public void Register(IServiceRegistration services, IDictionary<string, object> data)
        {
            services.RegisterSingleton(r => r
                .Types(t => t.AssignableTo<IValidator>())
                .As(s => s.Self().ImplementedInterfaces())
            );
        }
    }
}
