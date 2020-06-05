using System;

namespace Api.Models
{
    public class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal AlcoholVol { get; set; }

        public int BreweryId { get; set; }

        public Brewery Brewery { get; set; }

        public Uri ImageUri { get; set; }
    }
}
