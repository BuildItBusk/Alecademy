using System;

namespace Api.Models
{
    public class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal AlcoholVol { get; set; }

        public int OriginId { get; set; }

        public Country Origin { get; set; }

        public Uri ImageUri { get; set; }
    }
}
