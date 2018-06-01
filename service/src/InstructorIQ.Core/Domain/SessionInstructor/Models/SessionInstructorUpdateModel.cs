using System;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionInstructorUpdateModel : EntityUpdateModel
    {
        #region Generated Properties
        public Guid SessionId { get; set; }
        public Guid InstructorId { get; set; }

        #endregion
    }
}