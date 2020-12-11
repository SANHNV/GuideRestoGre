using System;

namespace GuideRestoGre.Data.Models
{
    /// <summary>
    /// Address Model
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Id 
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// ZipCode
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

    }
}
