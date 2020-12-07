using System;
using System.Collections.Generic;
using System.Text;

namespace GuideRestoGre.Data.Models
{
    public class Restaurant
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string Description { get; set; }

        public string Mail { get; set; }

        public Address Address { get; set; }
    }
}
