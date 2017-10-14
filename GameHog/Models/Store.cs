using System;
using System.Collections.Generic;
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
        public string StoreName { get; set; }

        //building, mall, etc name
        public string LocationName { get; set; }

        //Store's Physical Address (later tied into Google Maps for easy searching by customer)
        public string StorePhysicalStreet { get; set; }
        public string StorePhysicalCity { get; set; }
        public string StorePhysicalState { get; set; }
        public string StorePhysicalZipCode { get; set; }

        //Store's hours of operation
        public DateTime StoreHours { get; set; }
        
        //Is this the customer's home location?
        public bool IsHomeStore { get; set; }

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