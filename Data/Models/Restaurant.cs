using System;

namespace GuideRestoGre.Data.Models
{
    /// <summary>
    /// Restaurant Model
    /// </summary>
    public class Restaurant
    {
        /// <summary>
        /// ID <see cref="Restaurant"/>
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Name of the <see cref="Restaurant"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Phone number of the <see cref="Restaurant"/>
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Description of the <see cref="Restaurant"/>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Contact mail of the <see cref="Restaurant"/>
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Address of <see cref="Restaurant"/>
        /// </summary>
        public Address Address { get; set; } = new Address();

        /// <summary>
        /// Grade of <see cref="Restaurant"/>
        /// </summary>
        public Grade Grade { get; set; } = new Grade();
    }
}
