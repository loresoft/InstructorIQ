using System;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class OrganizationReadModel : EntityReadModel<Guid>
    {
        #region Generated Properties
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }

        #endregion
    }
}