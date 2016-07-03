using Microsoft.Azure.Mobile.Server;
using System;

namespace CoffeeCupsAppService.DataObjects
{

    public class CupOfCoffee: EntityData
    {
   
        public string UserId { get; set; }

        public string Id { get; set; }

        public string AzureVersion { get; set; }

        public DateTime DateUtc { get; set; }

        public bool MadeAtHome { get; set; }

        public string OS { get; set; }


        public string DateDisplay { get { return DateUtc.ToLocalTime().ToString("d"); } }

        public string TimeDisplay { get { return DateUtc.ToLocalTime().ToString("t"); } }

        public string AtHomeDisplay { get { return MadeAtHome ? "Made At Home" : string.Empty; } }
    }
}