using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameHog.Models
{
    //This class is for all of the various systems and system bundles for each type of system (ie: PS4 500gb system, PS4 1tb system, PS4 with Call of Duty 4, PS4 with Battlefield, etc, etc)
    public class SystemBundle
    {
        public int SystemBundleId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        //This keeps the string length lower than 255 characters.
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 50 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string SystemBundleName { get; set; }

        [DataType(DataType.MultilineText)]
        //This keeps the string length lower than 255 characters.
        [StringLength(500, MinimumLength = 3, ErrorMessage = "The description must be between 3 and 500 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string SystemBundleDescription { get; set; }


        public string HardwareId { get; set; }

        [ForeignKey("HardwareId")]
        public virtual Hardware Hardwares { get; set; }

    }
}