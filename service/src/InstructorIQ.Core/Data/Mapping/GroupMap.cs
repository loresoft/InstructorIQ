using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using InstructorIQ.Core.Data.Entities;

namespace InstructorIQ.Core.Data.Mapping
{
    public partial class GroupMap
    {
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<InstructorIQ.Core.Data.Entities.Group> builder)
        {
            // add mapping overrides here
        }
    }
}
