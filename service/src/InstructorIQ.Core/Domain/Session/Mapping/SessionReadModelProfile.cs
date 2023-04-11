using EntityChange;

using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

public class SessionReadModelProfile : EntityProfile<SessionReadModel>
{
    public override void Configure()
    {
        AutoMap();

        Property(p => p.StartDate).Formatter(v => v?.ToString("d"));
        Property(p => p.StartTime).Formatter(v => v?.ToString("t"));
        Property(p => p.EndDate).Formatter(v => v?.ToString("d"));
        Property(p => p.EndTime).Formatter(v => v?.ToString("t"));

        Property(p => p.TenantId).Ignore();
        Property(p => p.TopicId).Ignore();
        Property(p => p.LocationId).Ignore();
        Property(p => p.GroupId).Ignore();
        Property(p => p.LeadInstructorId).Ignore();
        Property(p => p.IsRequired).Ignore();

        Property(p => p.Created).Ignore();
        Property(p => p.CreatedBy).Ignore();
        Property(p => p.Updated).Ignore();
        Property(p => p.UpdatedBy).Ignore();
        Property(p => p.RowVersion).Ignore();

        Property(p => p.PeriodStart).Ignore();
        Property(p => p.PeriodEnd).Ignore();
    }
}
