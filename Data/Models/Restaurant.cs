﻿using System;
using System.ComponentModel.DataAnnotations;

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
        [MaxLength(10)]

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
        /// Address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Grade
        /// </summary>
        public Grade Grade { get; set; }
    }
}
