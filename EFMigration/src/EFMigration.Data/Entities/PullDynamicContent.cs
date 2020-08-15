using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFMigration.Data.Entities
{
    public class PullDynamicContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string HotelId { get; set; }

        [Required]
        [StringLength(50)]
        public string RateId { get; set; }

        public DateTime ChangedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        //public ICollection<PullDynamicContentDetail> PullDynamicDetails { get; set; }
    }
}