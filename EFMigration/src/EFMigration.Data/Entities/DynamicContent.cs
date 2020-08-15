﻿using System.Collections.Generic;

namespace EFMigration.Data.Entities
{
    public class DynamicContent : BaseLogEntity
    {
        public ICollection<DynamicContentDetail> DynamicDetails { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}