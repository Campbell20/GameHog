using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameHog.Models
{
    public class Hardware
    {
        //database idenity number for all hardware devices
        public int Id { get; set; }

        //The name of the hardware device
        public string HardwareName { get; set; }

        //A given description from a review site, or the Hardware develpoers themselves. If not present, then our employees will have to create one
        public string HardwareDescription { get; set; }

        //Is the Hardware available in our store?
        public bool HardwareAvailability { get; set; }

        //How many games do we have at the store?
        public int HardwareAvailabilityCount { get; set; }

        //Can we only ship to the US (large items can't be shipped outside of the US) or can we ship world wide?
        public bool HardwareShippingUSAOnly { get; set; }

 




        public string DeveloperName { get; set; }

        public string PublisherName { get; set; }

        //Is this piece of hardware available at a store?
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public virtual Store Stores { get; set; }



      
    }
}