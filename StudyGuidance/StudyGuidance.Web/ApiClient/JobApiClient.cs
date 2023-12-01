using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StudyGuidance.Web.Models;
using static System.Net.WebRequestMethods;

namespace StudyGuidance.Web.ApiClient
{
	public class JobApiClient : BaseApiClient, IJobApiClient
    {

		private string _url = $"https://localhost:7109/api/Quiz";

        public JobApiClient(HttpClient httpClient, ILogger<JobApiClient> logger) : base(httpClient, logger)
		{
		}

        public async Task<List<Option>> GetAllSubDomains()
        {
            return await GetJsonAsync<List<Option>>("https://localhost:7109/api/Quiz/subdomains?domainId=1&domainId=2&domainId=3&domainId=4&domainId=5&domainId=6&domainId=7");
        }

        public async Task<List<Option>> GetAllDomains()
        {
            return await GetJsonAsync<List<Option>>($"{_url}/domains");
        }

        public async Task<Job> GetJobByIdAsync(int id)
		{
			return await GetJsonAsync<Job>($"{_url}/jobs/detail/{id}");
		}

        public async Task<List<Job>> GetJobsAsync()
        {
            return await GetJsonAsync<List<Job>>($"{_url}/jobs");
        }

        public async Task<List<Job>> GetJobsByFilterAsync(List<string> subdomains, bool workInTeam, bool workOnSite)
        {
            string url = $"{_url}/jobsByFilter?subdomains={string.Join(",", subdomains)}&workInTeam={workInTeam}&workOnSite={workOnSite}";
            return await GetJsonAsync<List<Job>>(url);
        }
    }
}
