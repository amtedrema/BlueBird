using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlueBird.Models
{
    public class UserFormViewModel
    {
        [BindProperty]
        public Guid UserFormFillingId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [Compare(nameof(IsTrue), ErrorMessage = "Please accept the terms")]
        [BindProperty]
        public bool IsAgreedToTerms { get; set; }
        public bool IsTrue => true;

        [Required(ErrorMessage = "Please select a sector")]
        [BindProperty]
        public List<int> SectorValues { get; set; }

        public List<SectorData> SectorData { get; set; } = new List<SectorData>();
    }
}
