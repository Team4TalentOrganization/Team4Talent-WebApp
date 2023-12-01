using StudyGuidance.Domain;

namespace StudyGuidance.AppLogic
{
    public interface IQuizRepository
    {
        Task<IReadOnlyList<Question>> GetQuestionsAsync();
        Task<IReadOnlyList<Question>> GetStandardQuizQuestionsAsync();
        Task<IReadOnlyList<Question>> GetTinderQuizQuestionsAsync();
        Task<IReadOnlyList<Option>> GetDomainsAsync();
        Task<IReadOnlyList<Option>> GetSubDomainsAsync(List<int> domainId);
        Task<IReadOnlyList<Job>> GetJobsAsync();
        Task<IReadOnlyList<Job>> GetJobsByFilterAsync(List<string> subdomains, bool workInTeam, bool workOnSite);
    }
}
