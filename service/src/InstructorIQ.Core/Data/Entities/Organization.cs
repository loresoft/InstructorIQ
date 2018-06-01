using System;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Organization : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {

    }
}