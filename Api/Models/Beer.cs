using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Beer
    {
        public int Id { get; }

        public string Name { get; set; }

        public decimal AlcoholVol { get; set; }

        public Country Origin { get; set; }

        public Uri ImageUri { get; set; }
    }
}
