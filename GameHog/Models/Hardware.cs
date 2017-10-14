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
        public int HardwareId { get; set; }

        //The name of the hardware device
        public string HardwareName { get; set; }

        //A given description from a fan site, or the game develpoers themselves. If not present, then our employees will have to create one
        public string HardwareDescription { get; set; }

        //Can we only ship to the US (large items can't be shipped outside of the US) or can we ship world wide?
        public bool HardwareShippingUSAOnly { get; set; }

        public int HardwareUPCCode { get; set; }

     
        ////Is this piece of hardware available at a store?
        //[ForeignKey("StoreId")]
        //public virtual Store Stores { get; set; }

        ////What publisher is promoting the device?
        //[ForeignKey("PublisherId")]
        //public virtual Publisher Publishers { get; set; }

        ////What developer created the device?
        //[ForeignKey("DeveloperId")]
        //public virtual Developers Developers { get; set; }
    }
}