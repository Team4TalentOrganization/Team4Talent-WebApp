using StudyGuidance.Domain;

namespace StudGuidance.Domain.Models
{
    public class JobDTO
    {
        public string? Name { get; set; }
        public string? Domain { get; set; }
        public string? SubDomain { get; set; }
        public string? Description { get; set; }
        public bool WorkInTeam { get; set; }
        public bool WorkOnSite { get; set; }
        public int JobId { get; set; }
        public List<StudyCourseDTO> AssociatedStudyCourses { get; set; }

        public JobDTO(Job job)
        {
            JobId = job.JobId;
            Name = job.Name;
            Domain = job.Domain;
            SubDomain = job.SubDomain;
            Description = job.Description;
            WorkInTeam = job.WorkInTeam;
            WorkOnSite = job.WorkOnSite;
        }
    }
}
