using System;
using EntityFrameworkCore.CommandQuery.Definitions;
using InstructorIQ.Core.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Location : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated, IHaveOrganization
    {

    }
}