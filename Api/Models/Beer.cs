using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Beer
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }

        public decimal AlcoholVol { get; set; }

        public Country Origin { get; set; }

        public Uri ImageUri { get; set; }
    }
}
