using System;

namespace EntityFrameworkCore.CommandQuery.Models
{
    public interface ITrackConcurrency
    {
        string RowVersion { get; set; }
    }
}