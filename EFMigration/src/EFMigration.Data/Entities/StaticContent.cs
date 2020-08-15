using System.Collections.Generic;

namespace EFMigration.Data.Entities
{
    public class StaticContent : BaseLogEntity
    {
        public short Type { get; set; }
        public string ContentPush { get; set; }
        public ICollection<StaticContentDetail> StaticDetails { get; set; }
    }
}