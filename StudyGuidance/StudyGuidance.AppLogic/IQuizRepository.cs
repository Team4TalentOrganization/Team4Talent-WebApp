using StudyGuidance.Domain;

namespace StudyGuidance.AppLogic
{
    public interface IQuizRepository
    {
        Task<IReadOnlyList<Question>> GetQuestionsAsync();
        Task<IReadOnlyList<Option>> GetDomainsAsync();
        Task<IReadOnlyList<Option>> GetSubDomainsAsync(List<int> domainId);
        Task<IReadOnlyList<Job>> GetJobsAsync();
        Task<IReadOnlyList<Job>> GetJobsBySubDomain(List<string> subdomains);
    }
}
