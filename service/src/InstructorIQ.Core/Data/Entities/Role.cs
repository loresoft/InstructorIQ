using System;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Role : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {

    }
}