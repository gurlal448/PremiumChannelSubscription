using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumChannelSubscription.BusinessLayer
{
    public class PremiumService
    {
        [Key]
        public int ServiceID { get; set; }

        public string ServiceName { get; set; }

        public float StartingPrice { get; set; }
    }
}
