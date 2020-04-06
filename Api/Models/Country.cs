using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Country
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; set; }
    }
}
