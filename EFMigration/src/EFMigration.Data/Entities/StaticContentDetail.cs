using System.ComponentModel.DataAnnotations.Schema;

namespace EFMigration.Data.Entities
{
    public class StaticContentDetail : BaseLogDetailEntity
    {
        [ForeignKey("MasterId")]
        public StaticContent Static { get; set; }
    }
}