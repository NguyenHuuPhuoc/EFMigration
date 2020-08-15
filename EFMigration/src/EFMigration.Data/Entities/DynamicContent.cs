using System.Collections.Generic;

namespace EFMigration.Data.Entities
{
    public class DynamicContent : BaseLogEntity
    {
        public ICollection<DynamicContentDetail> DynamicDetails { get; set; }
        public string Test { get; set; }
    }
}