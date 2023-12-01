namespace StudyGuidance.Web.Models
{
    public class Job
    {
        public string? Name  { get; set; }
        public string? Domain { get; set; }
        public string? SubDomain { get; set; }
        public string? Description { get; set; }
        public bool WorkInTeam { get; set; }
        public bool WorkOnSite { get; set; }
        public int JobId { get; set; }


    }
}
