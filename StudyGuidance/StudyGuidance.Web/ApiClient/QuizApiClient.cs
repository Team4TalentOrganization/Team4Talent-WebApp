using Microsoft.Extensions.Primitives;
using StudyGuidance.Web.Models;
using System.Text;

namespace StudyGuidance.Web.ApiClient
{
    public class QuizApiClient : BaseApiClient, IQuizApiClient
    {
        private string _url = $"https://localhost:7109/api/";

        public QuizApiClient(HttpClient httpClient, ILogger<BaseApiClient> logger) : base(httpClient, logger)
        {
        }

        public async Task<List<Question>> GetAllDomainQuestions()
        {
            return await GetJsonAsync<List<Question>>($"{_url}Quiz/domainquestions");
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            return await GetJsonAsync<List<Question>>($"{_url}Quiz/questions");
        }

        public async Task<List<Question>> GetAllStandardQuizQuestions()
        {
            return await GetJsonAsync<List<Question>>($"{_url}Quiz/standardquizquestions");
        }

        public async Task<List<Question>> GetAllTinderQuizQuestions()
        {
            return await GetJsonAsync<List<Question>>($"{_url}Quiz/tinderquizquestions");
        }
        public async Task<List<Option>> GetAllSubDomains()
        {
			return await GetJsonAsync<List<Option>>($"{_url}Quiz/subdomains/all");
        }

        public async Task<List<Question>> GetSubdomains(List<int> domainIds)
        {
            StringBuilder endpointBuilder = new StringBuilder();
            endpointBuilder.Append(_url);
            endpointBuilder.Append("Quiz/subdomains?");
            bool isFirstDomain = true;

            foreach (int domainId in domainIds)
            {
                if (!isFirstDomain)
                {
                    endpointBuilder.Append("&");
                }

                endpointBuilder.Append($"domainId={domainId}");

                isFirstDomain = false;
            }

            string endpointString = endpointBuilder.ToString();

            return await GetJsonAsync<List<Question>>(endpointString);
        }
    }
}
