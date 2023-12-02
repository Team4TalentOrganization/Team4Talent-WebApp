using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.ApiClient
{
    public interface IQuizApiClient
    {
        Task<List<Question>> GetAllQuestions();
        Task<List<Question>> GetAllStandardQuizQuestions();
        Task<List<Option>> GetSubdomains(List<int> domainIds);
    }
}
