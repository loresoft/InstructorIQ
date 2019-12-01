using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class MemberImportModel
    {
        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string SortName { get; set; }
        
        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public string PhoneNumber { get; set; }

        public string JobTitle { get; set; }
    }
}