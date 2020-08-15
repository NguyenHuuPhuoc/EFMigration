using System;

namespace EFMigration.Data.Entities
{
    public abstract class BaseLogEntity
    {
        public long Id { get; set; }
        public string EntityId { get; set; }
        public string Content { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}