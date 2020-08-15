using System.ComponentModel.DataAnnotations.Schema;

namespace EFMigration.Data.Entities
{
    public class DynamicContentDetail : BaseLogDetailEntity
    {
        [ForeignKey("MasterId")]
        public DynamicContent Dynamic { get; set; }
    }
}