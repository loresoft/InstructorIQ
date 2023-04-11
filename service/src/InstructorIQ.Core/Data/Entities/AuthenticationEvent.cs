using System;
using System.Collections.Generic;

using MediatR.CommandQuery.Definitions;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'AuthenticationEvent'.
/// </summary>
public partial class AuthenticationEvent : IHaveIdentifier<Guid>, ITrackCreated, ITrackUpdated
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationEvent"/> class.
    /// </summary>
    public AuthenticationEvent()
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
    /// Gets or sets the property value representing column 'EmailAddress'.
    /// </summary>
    /// <value>
    /// The property value representing column 'EmailAddress'.
    /// </value>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'UserName'.
    /// </summary>
    /// <value>
    /// The property value representing column 'UserName'.
    /// </value>
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'UserAgent'.
    /// </summary>
    /// <value>
    /// The property value representing column 'UserAgent'.
    /// </value>
    public string UserAgent { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'Browser'.
    /// </summary>
    /// <value>
    /// The property value representing column 'Browser'.
    /// </value>
    public string Browser { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'OperatingSystem'.
    /// </summary>
    /// <value>
    /// The property value representing column 'OperatingSystem'.
    /// </value>
    public string OperatingSystem { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'DeviceFamily'.
    /// </summary>
    /// <value>
    /// The property value representing column 'DeviceFamily'.
    /// </value>
    public string DeviceFamily { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'DeviceBrand'.
    /// </summary>
    /// <value>
    /// The property value representing column 'DeviceBrand'.
    /// </value>
    public string DeviceBrand { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'DeviceModel'.
    /// </summary>
    /// <value>
    /// The property value representing column 'DeviceModel'.
    /// </value>
    public string DeviceModel { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'IpAddress'.
    /// </summary>
    /// <value>
    /// The property value representing column 'IpAddress'.
    /// </value>
    public string IpAddress { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'IsSuccessful'.
    /// </summary>
    /// <value>
    /// The property value representing column 'IsSuccessful'.
    /// </value>
    public bool IsSuccessful { get; set; }

    /// <summary>
    /// Gets or sets the property value representing column 'FailureMessage'.
    /// </summary>
    /// <value>
    /// The property value representing column 'FailureMessage'.
    /// </value>
    public string FailureMessage { get; set; }

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
