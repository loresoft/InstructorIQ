using System;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class HistoryRecord : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {

    }
}