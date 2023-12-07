using StudyGuidance.Domain;

namespace StudyGuidance.AppLogic
{
    public interface IJobRepository
    {
        Task<IReadOnlyList<Job>> GetJobsAsync();
        Task<IReadOnlyList<Job>> GetJobsByFilterAsync(List<int> subdomainIds, bool workInTeam, bool workOnSite);
        Task<Job> GetJobByIdAsync(int id);
    }
}
