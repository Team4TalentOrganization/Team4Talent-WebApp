using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;

namespace StudyGuidance.AppLogic
{
    public interface IJobRepository
    {
        Task<IReadOnlyList<Job>> GetJobsAsync();
        Task<IReadOnlyList<Job>> GetJobsByFilterAsync(List<int> subdomainIds, bool workInTeam, bool workOnSite);
        Task<Job> GetJobByIdAsync(int id);
        Task<Job> AddJobAsync(JobRequest jobRequest);
        Task<Job> ChangeJobAsync(Job job);
        Task<bool> DeleteJobAsync(int id);
    }
}
