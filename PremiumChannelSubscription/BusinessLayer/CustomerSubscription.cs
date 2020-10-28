using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumChannelSubscription.BusinessLayer
{
    public class CustomerSubscription
    {
        
        public int CustomerSubscriptionID { get; set; }

        public int ServiceID { get; set; }

        public PremiumService Service { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public float Amount { get; set; }


    }
}
