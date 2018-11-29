using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    /// <summary>
    /// View Model class
    /// </summary>
    public class HistoryRecordReadModel
        : EntityReadModel<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'Key'.
        /// </summary>
        /// <value>
        /// The property value for 'Key'.
        /// </value>
        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Entity'.
        /// </summary>
        /// <value>
        /// The property value for 'Entity'.
        /// </value>
        public string Entity { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'ParentKey'.
        /// </summary>
        /// <value>
        /// The property value for 'ParentKey'.
        /// </value>
        public Guid? ParentKey { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'ParentEntity'.
        /// </summary>
        /// <value>
        /// The property value for 'ParentEntity'.
        /// </value>
        public string ParentEntity { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Changed'.
        /// </summary>
        /// <value>
        /// The property value for 'Changed'.
        /// </value>
        public DateTimeOffset Changed { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'ChangedBy'.
        /// </summary>
        /// <value>
        /// The property value for 'ChangedBy'.
        /// </value>
        public string ChangedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'PropertyName'.
        /// </summary>
        /// <value>
        /// The property value for 'PropertyName'.
        /// </value>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'DisplayName'.
        /// </summary>
        /// <value>
        /// The property value for 'DisplayName'.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Path'.
        /// </summary>
        /// <value>
        /// The property value for 'Path'.
        /// </value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Operation'.
        /// </summary>
        /// <value>
        /// The property value for 'Operation'.
        /// </value>
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'OriginalValue'.
        /// </summary>
        /// <value>
        /// The property value for 'OriginalValue'.
        /// </value>
        public string OriginalValue { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'OriginalFormated'.
        /// </summary>
        /// <value>
        /// The property value for 'OriginalFormated'.
        /// </value>
        public string OriginalFormated { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'OriginalType'.
        /// </summary>
        /// <value>
        /// The property value for 'OriginalType'.
        /// </value>
        public string OriginalType { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'CurrentValue'.
        /// </summary>
        /// <value>
        /// The property value for 'CurrentValue'.
        /// </value>
        public string CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'CurrentFormated'.
        /// </summary>
        /// <value>
        /// The property value for 'CurrentFormated'.
        /// </value>
        public string CurrentFormated { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'CurrentType'.
        /// </summary>
        /// <value>
        /// The property value for 'CurrentType'.
        /// </value>
        public string CurrentType { get; set; }

        #endregion

    }
}
