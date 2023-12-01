using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.ApiClient
{
    public class QuizApiClient : BaseApiClient, IQuizApiClient
    {
        private string _url = $"https://localhost:7109/api/Quiz";

        public QuizApiClient(HttpClient httpClient, ILogger<BaseApiClient> logger) : base(httpClient, logger)
        {
        }

        public async Task<List<Question>> GetAllQuestion()
        {
            return await GetJsonAsync<List<Question>>($"{_url}/questions");
        }
    }
}
