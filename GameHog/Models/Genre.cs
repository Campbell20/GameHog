using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameHog.Models
{

    //This is the genre of the game... Is it an FPS,RTS, Roleplaying? 
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}