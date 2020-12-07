using System;
using System.Collections.Generic;
using System.Text;

namespace GuideRestoGre.Data.Models
{
    public class Grade
    {
        public Guid ID { get; set; }

        public DateTime LastVisit { get; set; }

        public string Comment { get; set; }

        public int Score { get; set; }
    }
}
