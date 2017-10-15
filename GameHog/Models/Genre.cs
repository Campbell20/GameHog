using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameHog.Models
{

    //This is the genre of the game... Is it an FPS,RTS, Roleplaying? 
    public class Genre
    {
        //This is the identifier of the genre
        public int GenreId { get; set; }

        //What is the name of the Genre? This is a required field.
        [Required]
        [DataType(DataType.Text)]
        //This keeps the string length lower than 255 characters.
        [StringLength(25, MinimumLength = 3, ErrorMessage = "A genre's name must be between 3 and 25 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string GenreName { get; set; }

        //What is the description of the genre? (Possibly get descriptions from wiki)
        //The datatype allows MVC to create a large text box for our description field in the genre's table
        [DataType(DataType.MultilineText)]
        //This keeps the string length lower than 255 characters.
        [StringLength(255, MinimumLength = 3, ErrorMessage = "A genre's description must be between 3 and 255 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string GenreDescription { get; set; }
    }
}