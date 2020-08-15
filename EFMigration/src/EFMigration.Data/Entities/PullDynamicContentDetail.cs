using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFMigration.Data.Entities
{
    public class PullDynamicContentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        //public long MasterId { get; set; }

        [Required]
        [StringLength(50)]
        public string HotelId { get; set; }

        [Required]
        [StringLength(50)]
        public string ChannelCode { get; set; }

        public DateTime ChangedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        //[ForeignKey("MasterId")]
        //public PullDynamicContent Dynamic { get; set; }
    }
}
