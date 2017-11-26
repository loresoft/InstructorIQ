using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data
{
    public interface IEntityIdentifier
    {
        Guid Id { get; set; }
    }
}
