using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameHog.Models
{
    public class Accessory
    {
        //database idenity number for all hardware devices
        public int AccessoryId { get; set; }

        //The name of the hardware device
        public string AccessoryName { get; set; }

        //A given description from a review site, or the Accessory develpoers themselves. If not present, then our employees will have to create one
        public string AccessoryDescription { get; set; }

        //Is the Accessory available in our store?
        public bool AccessoryAvailability { get; set; }

        //How many Accessorys do we have at the store?
        public int AccessoryAvailabilityCount { get; set; }

        //Can we only ship to the US (large items can't be shipped outside of the US) or can we ship world wide?
        public bool AccessoryShippingUSAOnly { get; set; }

        public int AccessoryUPCCode { get; set; }

        public string DeveloperName { get; set; }

        public string PublisherName { get; set; }




    }
}