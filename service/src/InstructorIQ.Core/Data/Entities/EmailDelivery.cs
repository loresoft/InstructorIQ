using System;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class EmailDelivery : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {

    }
}