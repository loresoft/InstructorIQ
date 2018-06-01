﻿using System;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class SessionGroupCreateModel : EntityCreateModel<Guid>
    {
        #region Generated Properties
        public Guid SessionId { get; set; }
        public Guid GroupId { get; set; }

        #endregion
    }
}