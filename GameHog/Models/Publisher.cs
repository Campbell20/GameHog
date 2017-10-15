using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameHog.Models
{
    //We are only tracking the publisher's name and website (if any)
    public class Publisher
    {
        //What is our unique identifier for the publisher 
        public int PublisherId { get; set; }


        //What is the publisher's name?
        [Required]
        [DataType(DataType.Text)]
        //This keeps the string length lower than 255 characters.
        [StringLength(25, MinimumLength = 3, ErrorMessage = "A hardware's name must be between 3 and 25 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string PublisherName { get; set; }

        //What is the publisher's website?
        [DataType(DataType.Url)]
        [RegularExpression("(http[s]?://)?([^/s]+/)(.*)", ErrorMessage = "The web address must be http://yourwebsite.com.")]
        public string PublisherWebsite { get; set; }
    }
}