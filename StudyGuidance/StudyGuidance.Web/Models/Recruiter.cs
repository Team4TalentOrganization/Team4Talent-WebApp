using System.ComponentModel.DataAnnotations;

namespace StudyGuidance.Web.Models
{
    public class Recruiter
    {
        public int RecruiterId { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mailadres is verplicht!")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bedrijf is verplicht!")]
        public string Company { get; set; }
    }
}
