using System;

namespace EFMigration.Data.Entities
{
    public abstract class BaseLogDetailEntity
    {
        public long Id { get; set; }
        public long MasterId { get; set; }
        public short? RetriedCount { get; set; }
        public string LastError { get; set; }
        public string Channel { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}