namespace StudyGuidance.Web.Models
{
    public class Recruiter
    {
        public int RecruiterId { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; }
        public string Company { get; set; }
    }
}
