using EntityChange;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping
{

    public class SessionInstructorModelProfile : EntityProfile<SessionInstructorModel>
    {
        public override void Configure()
        {
            AutoMap();

            Property(p => p.SessionId).Ignore();
            Property(p => p.InstructorId).Ignore();

            Property(p => p.Created).Ignore();
            Property(p => p.CreatedBy).Ignore();
            Property(p => p.Updated).Ignore();
            Property(p => p.UpdatedBy).Ignore();
            Property(p => p.RowVersion).Ignore();

            Property(p => p.PeriodStart).Ignore();
            Property(p => p.PeriodEnd).Ignore();
        }
    }
}