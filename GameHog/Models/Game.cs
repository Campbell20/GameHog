using System;
using System.Collections.Generic;
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
        public string GameName { get; set; }

        //A given description from a review site, or the game develpoers themselves. If not present, then our employees will have to create one
        public string GameDescription { get; set; }

        //Is the game available in our store?
        public bool GameAvailability { get; set; }

        //How many games do we have at the store?
        public int GameAvailabilityCount { get; set; }

        //Can we only ship to the US (large items can't be shipped outside of the US) or can we ship world wide?
        public bool GameShippingUSAOnly { get; set; }

        public int GameUPCCode { get; set; }

        public int GameESRBRating { get; set; }



        //Is this piece of hardware available at a store?
        public int StoresId { get; set; }
        [ForeignKey("StoresId")]
        public virtual Store Stores { get; set; }

        //What hardware is this game tied too?
        public int HardwaresId { get; set; }
        [ForeignKey("HardwaresId")]
        public virtual Hardware Hardwares { get; set; }

        //What publisher is promoting the game?
        public int PublishersId { get; set; }
        [ForeignKey("PublishersId")]
        public virtual Publisher Publishers { get; set; }

        //What developer created the device?
        public int DevelopersId { get; set; }
        [ForeignKey("DevelopersId")]
        public virtual Developer Developers { get; set; }

        //What type of game is the game?
        public int GenresId { get; set; }
        [ForeignKey("GenresId")]
        public virtual Genre Genres { get; set; }
    }
}