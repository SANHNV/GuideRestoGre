using System;
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
        public int Score { get; set; }

        /// <summary>
        /// RestaurantId FK
        /// </summary>
        [ForeignKey("Restaurant")]
        public virtual Guid RestaurantId { get; set; }

    }
}
