using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameHog.Models
{
    public class Store
    {
        //Store's unique identification number in the table
        public int StoreId { get; set; }

        //Store name (such as GameStop, EB Games, etc)
        #region Store Name
        [Required]
        [DataType(DataType.Text)]
        //This keeps the string length lower than 255 characters.
        [StringLength(25, MinimumLength = 3, ErrorMessage = "A store's name must be between 3 and 25 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string StoreName { get; set; }
        #endregion

        //building, mall, etc name
        #region Store Location Name 
        [Required]
        [DataType(DataType.Text)]
        //This keeps the string length lower than 255 characters.
        [StringLength(25, MinimumLength = 3, ErrorMessage = "A store's location name must be between 3 and 25 characters only.")]
        //This regular expression will take any length string but requires the user to only use 1 space between words or letters.
        [RegularExpression(@"^((\w+ )*\w+)?$", ErrorMessage = "You cannot have more than 1 space between words.")]
        public string LocationName { get; set; }
        #endregion

        //Store's Physical Address (later tied into Google Maps for easy searching by customer)
        #region PhysicalAddress
        [Required]        
        [Display(Name = "Store Address")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The street must be between 3 and 50 characters.")]
        public string StorePhysicalStreet { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The city must be between 3 and 50 characters.")]
        public string StorePhysicalCity { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The state must be between 3 and 50 characters.")]
        public string StorePhysicalState { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Zipcode is Required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zipcode")]
        public string StorePhysicalZipCode { get; set; }
        #endregion

        //Store's hours of operation as a string (possibly adjust this to DateTime method later)
        #region Hours of Operation

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "The hours of operation can only be between 3 and 500 characters.")]
        public string StoreHours { get; set; }
        //This datatype won't work because it only captures one instance of time... Maybe ask Carlos how to fix this.
        //[DataType(DataType.Time)]
        //public DateTime StoreHours { get; set; }
#endregion

        //Is this the customer's home location?
        public bool IsHomeStore { get; set; }

        //Mailing address of store - currently not functioning
        #region MailingAddress

        /// <summary>
        /// Removed mailing address from this model, because it's backend (district manager infromation that the customer doersn't need at this time.)
        /// </summary>

        ////Is theere a different mailing address? If so, check block
        //public bool IsStoreMailingDifferent { get; set; }


        ////The Store's mailing address if there is one
        //public int MailingStreetNumber { get; set; }
        //public string MailingStreetName { get; set; }
        ////street identifer (such as St., Dr., Ave., Ln., etc, etc)
        //public int MailingStreetIdentifier { get; set; }

        //// suite number if there is one
        //public int MailingStreetSecondaryIdentifier { get; set; }

        ////Store's City Name
        //public string MailingCity { get; set; }

        ////Store's State
        //public string MailingState { get; set; }

        ////Store's Zipcode
        //public int MailingZipCode { get; set; }

        #endregion

    }
}