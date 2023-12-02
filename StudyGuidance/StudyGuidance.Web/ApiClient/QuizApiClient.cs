using Microsoft.Extensions.Primitives;
using StudyGuidance.Web.Models;
using System.Text;

namespace StudyGuidance.Web.ApiClient
{
    public class QuizApiClient : BaseApiClient, IQuizApiClient
    {
        private string _url = $"https://localhost:7109/api/Quiz";

        public QuizApiClient(HttpClient httpClient, ILogger<BaseApiClient> logger) : base(httpClient, logger)
        {
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            return await GetJsonAsync<List<Question>>($"{_url}/questions");
        }

        public async Task<List<Question>> GetAllStandardQuizQuestions()
        {
            return await GetJsonAsync<List<Question>>($"{_url}/standardquizquestions");
        }

        public async Task<List<Option>> GetSubdomains(List<int> domainIds)
        {
            StringBuilder endpointBuilder = new StringBuilder();
            endpointBuilder.Append(_url);
            endpointBuilder.Append("/subdomains?");
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

            return await GetJsonAsync<List<Option>>(endpointString);
        }
    }
}
