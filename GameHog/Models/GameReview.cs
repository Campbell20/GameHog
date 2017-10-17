using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameHog.Models
{

    //We will probably need to add more to this model as it develops over time
    public class GameReview 
    {

        public int GameReviewId { get; set; }

        [DataType(DataType.Text)]
        //This keeps the string length lower than 255 characters.
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The description must be between 3 and 50 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string GameReviewName { get; set; }


        [DataType(DataType.MultilineText)]
        //This keeps the string length lower than 255 characters.
        [StringLength(500, MinimumLength = 3, ErrorMessage = "The description must be between 3 and 500 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string GameReviewDescription { get; set; }

        //How many stars did the game recieve?
        public int GameReviewStarValue { get; set; }
   
        //many reviews but only 1 game
        public int GamesId { get; set; }
        [ForeignKey("GamesId")]
        public virtual Game Games { get; set; }

        public int AccesoryId { get; set; }
        [ForeignKey("AccesoryId")]
        public virtual Accessory Accessories { get; set; }
    }
}