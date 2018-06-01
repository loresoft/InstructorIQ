using System;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class EmailTemplate : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {

    }
}