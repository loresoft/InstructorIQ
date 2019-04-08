using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'HistoryRecord'.
    /// </summary>
    public partial class HistoryRecord : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryRecord"/> class.
        /// </summary>
        public HistoryRecord()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value representing column 'Id'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Id'.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Key'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Key'.
        /// </value>
        public Guid Key { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Entity'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Entity'.
        /// </value>
        public string Entity { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'ParentKey'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ParentKey'.
        /// </value>
        public Guid? ParentKey { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'ParentEntity'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ParentEntity'.
        /// </value>
        public string ParentEntity { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Changed'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Changed'.
        /// </value>
        public DateTimeOffset Changed { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'ChangedBy'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ChangedBy'.
        /// </value>
        public string ChangedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'PropertyName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'PropertyName'.
        /// </value>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'DisplayName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'DisplayName'.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Path'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Path'.
        /// </value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Operation'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Operation'.
        /// </value>
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'OriginalValue'.
        /// </summary>
        /// <value>
        /// The property value representing column 'OriginalValue'.
        /// </value>
        public string OriginalValue { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'OriginalFormated'.
        /// </summary>
        /// <value>
        /// The property value representing column 'OriginalFormated'.
        /// </value>
        public string OriginalFormated { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'OriginalType'.
        /// </summary>
        /// <value>
        /// The property value representing column 'OriginalType'.
        /// </value>
        public string OriginalType { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'CurrentValue'.
        /// </summary>
        /// <value>
        /// The property value representing column 'CurrentValue'.
        /// </value>
        public string CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'CurrentFormated'.
        /// </summary>
        /// <value>
        /// The property value representing column 'CurrentFormated'.
        /// </value>
        public string CurrentFormated { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'CurrentType'.
        /// </summary>
        /// <value>
        /// The property value representing column 'CurrentType'.
        /// </value>
        public string CurrentType { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Created'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Created'.
        /// </value>
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'CreatedBy'.
        /// </summary>
        /// <value>
        /// The property value representing column 'CreatedBy'.
        /// </value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Updated'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Updated'.
        /// </value>
        public DateTimeOffset Updated { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'UpdatedBy'.
        /// </summary>
        /// <value>
        /// The property value representing column 'UpdatedBy'.
        /// </value>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'RowVersion'.
        /// </summary>
        /// <value>
        /// The property value representing column 'RowVersion'.
        /// </value>
        public Byte[] RowVersion { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
