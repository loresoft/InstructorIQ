using System;

namespace EntityFrameworkCore.CommandQuery.Models
{
    public interface IHaveIdentifier<TKey>
    {
        TKey Id { get; set; }
    }
}