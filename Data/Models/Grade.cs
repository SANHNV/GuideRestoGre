using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuideRestoGre.Data.Models
{
    /// <summary>
    /// Model for Grade
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// ID of <see cref="Grade"/>
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Date last visit of a client
        /// </summary>
        public DateTime LastVisit { get; set; }

        /// <summary>
        /// Last comment of a client
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Score attributed
        /// </summary>
        [MaxLength(1)]
        public int Score { get; set; }

        [ForeignKey("Restaurant")]
        public virtual Guid RestaurantId { get; set; }

    }
}
