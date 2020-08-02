using System;
using System.Collections.Generic;

namespace RestApiMySQLNetCore31.Models
{
    public partial class Changelog
    {
        public int Id { get; set; }
        public byte? Type { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Checksum { get; set; }
        public string InstalledBy { get; set; }
        public DateTimeOffset InstalledOn { get; set; }
        public byte Success { get; set; }
    }
}
