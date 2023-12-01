using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.ApiClient
{
    public interface IQuizApiClient
    {
        Task<List<Question>> GetAllQuestion();
    }
}
