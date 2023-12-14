using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.ApiClient
{
    public interface IQuizApiClient
    {
        Task<List<Question>> GetAllQuestions();
        Task<List<Question>> GetAllDomainQuestions();
        Task<List<Question>> GetAllStandardQuizQuestions();
        Task<List<Question>> GetAllTinderQuizQuestions();
        Task<List<Option>> GetAllSubDomains();
        Task<List<Question>> GetSubdomains(List<int> domainIds);
    }
}
