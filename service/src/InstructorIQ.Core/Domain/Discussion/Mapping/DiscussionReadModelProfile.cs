using EntityChange;

using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Mapping;

public class DiscussionReadModelProfile : EntityProfile<DiscussionReadModel>
{
    public override void Configure()
    {
        AutoMap();

        Property(p => p.TenantId).Ignore();
        Property(p => p.TopicId).Ignore();

        Property(p => p.UserAgent).Ignore();
        Property(p => p.Browser).Ignore();
        Property(p => p.OperatingSystem).Ignore();
        Property(p => p.DeviceFamily).Ignore();
        Property(p => p.DeviceBrand).Ignore();
        Property(p => p.DeviceModel).Ignore();
        Property(p => p.IpAddress).Ignore();

        Property(p => p.Created).Ignore();
        Property(p => p.CreatedBy).Ignore();
        Property(p => p.Updated).Ignore();
        Property(p => p.UpdatedBy).Ignore();
        Property(p => p.RowVersion).Ignore();

        Property(p => p.PeriodStart).Ignore();
        Property(p => p.PeriodEnd).Ignore();
    }
}
