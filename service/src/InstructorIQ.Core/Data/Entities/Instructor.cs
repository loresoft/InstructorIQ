﻿using System;
using System.Collections.Generic;
using System.Text;
using InstructorIQ.Core.Data.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class Instructor : IEntityIdentifier, IEntityChangeTracking, IEntityVersion, IHaveOrganization
    {

    }
}