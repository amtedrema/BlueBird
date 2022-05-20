using System.ComponentModel.DataAnnotations;

namespace BlueBird.Models
{
    public class SectorBase
    {
        [Key]
        public Guid SectorId { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
