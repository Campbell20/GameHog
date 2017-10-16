using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameHog.Models
{
    public abstract class NameDescription
    {
        public int NameDescriptionId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        //This keeps the string length lower than 255 characters.
        [StringLength(25, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 25 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        //This keeps the string length lower than 255 characters.
        [StringLength(500, MinimumLength = 3, ErrorMessage = "The description must be between 3 and 500 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string Description { get; set; }

    }
}