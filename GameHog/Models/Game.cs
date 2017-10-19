using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameHog.Models
{
    public class Game
    {
        //database idenity number for all hardware devices
        public int GameId { get; set; }

        //The name of the hardware device
        [Required]
        [DataType(DataType.Text)]
        //This keeps the string length lower than 255 characters.
        [StringLength(25, MinimumLength = 3, ErrorMessage = "A game's name must be between 3 and 25 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string GameName { get; set; }

        //A given description from a review site, or the game develpoers themselves. If not present, then our employees will have to create one
        [Required]
        [DataType(DataType.MultilineText)]
        //This keeps the string length lower than 255 characters.
        [StringLength(500, MinimumLength = 3, ErrorMessage = "A game's description must be between 3 and 500 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string GameDescription { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float? GamePrice { get; set; }

        //Is the game available in our store?
        [Required]
        public bool GameAvailability { get; set; }

        //How many games do we have at the store?
        [Required]
        public int GameAvailabilityCount { get; set; }

        //Can we only ship to the US (large items can't be shipped outside of the US) or can we ship world wide?
        [Required]
        public bool GameShippingUSAOnly { get; set; }

        //WHat is teh game's upc code?
        [Required]
        public int GameUPCCode { get; set; }

        //What rating does the game currently have?
        /// <summary>
        /// 0 - early childhood
        /// 1 - everyone
        /// 2 - everyone 10+
        /// 3 - teen
        /// 4 - mature 17+
        /// 5 - adults only 18+
        /// </summary>
        public int GameESRBRating { get; set; }


        public string DeveloperName { get; set; }

        public string PublisherName { get; set; }



        //Is this piece of hardware available at a store?
        public int StoresId { get; set; }
        [ForeignKey("StoresId")]
        public virtual Store Stores { get; set; }

        //What hardware is this game tied too?
        public int HardwaresId { get; set; }
        [ForeignKey("HardwaresId")]
        public virtual Hardware Hardwares { get; set; }   

        //What type of game is the game?
        public int GenresId { get; set; }
        [ForeignKey("GenresId")]
        public virtual Genre Genres { get; set; }
    }
}