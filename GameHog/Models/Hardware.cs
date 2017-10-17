using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Text)]
        //This keeps the string length lower than 255 characters.
        [StringLength(25, MinimumLength = 3, ErrorMessage = "A hardware's name must be between 3 and 25 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string HardwareName { get; set; }

        //A given description from a fan site, or the game develpoers themselves. If not present, then our employees will have to create one
        //The datatype allows MVC to create a large text box for our description field in the genre's table
        [DataType(DataType.MultilineText)]
        //This keeps the string length lower than 255 characters.
        [StringLength(500, MinimumLength = 3, ErrorMessage = "A hardware's description must be between 3 and 500 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string HardwareDescription { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float? AccessoryPrice { get; set; }
        //Can we only ship to the US (large items can't be shipped outside of the US) or can we ship world wide?
        [Required]
        public bool HardwareShippingUSAOnly { get; set; }

        //What is the hardware's upc code?
        [Required]
        public int HardwareUPCCode { get; set; }


        ////Is this piece of hardware available at a store?
        //public int StoresId { get; set; }
        //[ForeignKey("StoresId")]
        //public virtual Store Stores { get; set; }
        
        ////What publisher is promoting the game?
        //public int PublishersId { get; set; }
        //[ForeignKey("PublishersId")]
        //public virtual Publisher Publishers { get; set; }

        ////What developer created the device?
        //public int DevelopersId { get; set; }
        //[ForeignKey("DevelopersId")]
        //public virtual Developer Developers { get; set; }

    
    }
}