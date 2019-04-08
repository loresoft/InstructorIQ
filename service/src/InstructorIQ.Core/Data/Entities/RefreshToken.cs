using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'RefreshToken'.
    /// </summary>
    public partial class RefreshToken : IHaveIdentifier<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshToken"/> class.
        /// </summary>
        public RefreshToken()
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
        /// Gets or sets the property value representing column 'TokenHashed'.
        /// </summary>
        /// <value>
        /// The property value representing column 'TokenHashed'.
        /// </value>
        public string TokenHashed { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'UserName'.
        /// </summary>
        /// <value>
        /// The property value representing column 'UserName'.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'ClientId'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ClientId'.
        /// </value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'ProtectedTicket'.
        /// </summary>
        /// <value>
        /// The property value representing column 'ProtectedTicket'.
        /// </value>
        public string ProtectedTicket { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Issued'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Issued'.
        /// </value>
        public DateTimeOffset Issued { get; set; }

        /// <summary>
        /// Gets or sets the property value representing column 'Expires'.
        /// </summary>
        /// <value>
        /// The property value representing column 'Expires'.
        /// </value>
        public DateTimeOffset? Expires { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
