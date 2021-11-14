using System;

namespace InstructorIQ.Core.Options
{
    public class StorageConfiguration
    {
        public const string ConfigurationName = "Storage";

        public string ConnectionString { get; set; }

        public string Container { get; set; }
    }
}
