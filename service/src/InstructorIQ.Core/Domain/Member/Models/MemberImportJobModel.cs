using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class MemberImportJobModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string[] Headers { get; set; }

        public string EmailMapping { get; set; }

        public string PhoneNumberMapping { get; set; }

        public string GivenNameMapping { get; set; }

        public string MiddleNameMapping { get; set; }

        public string FamilyNameMapping { get; set; }

        public string DisplayNameMapping { get; set; }

        public string SortNameMapping { get; set; }

        public string JobTitleMapping { get; set; }
    }
}
