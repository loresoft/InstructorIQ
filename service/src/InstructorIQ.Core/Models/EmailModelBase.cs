// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public abstract class EmailModelBase
    {
        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }
    }
}