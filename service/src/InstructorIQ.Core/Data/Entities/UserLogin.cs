using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class UserLogin : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {

    }
}