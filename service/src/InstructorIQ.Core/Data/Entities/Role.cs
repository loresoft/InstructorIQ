using System;
using System.Collections.Generic;
using System.Text;
using InstructorIQ.Core.Data.Definitions;
using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Data.Entities
{
    public class Role : IdentityRole<Guid>, IEntityIdentifier
    {

    }
}