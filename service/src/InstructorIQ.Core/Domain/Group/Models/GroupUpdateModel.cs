using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class GroupUpdateModel : EntityUpdateModel
    {
        #region Generated Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }

        #endregion
    }
}