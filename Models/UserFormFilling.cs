using System.ComponentModel.DataAnnotations;

namespace BlueBird.Models
{
    public class UserFormFilling
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAgreedToTerms { get; set; }
        public ICollection<Sector> Sectors { get; set; }
    }
}
