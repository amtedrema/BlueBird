using System.ComponentModel.DataAnnotations.Schema;

namespace BlueBird.Models
{
    public class Sector : SectorBase
    {
        [ForeignKey("UserFormFillingId")]
        public UserFormFilling UserFormFilling { get; set; }
    }
}
