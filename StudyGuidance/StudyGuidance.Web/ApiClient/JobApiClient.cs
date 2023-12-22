using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StudyGuidance.Web.Models;
using static System.Net.WebRequestMethods;

namespace StudyGuidance.Web.ApiClient
{
	public class JobApiClient : BaseApiClient, IJobApiClient
    {

		private string _url = $"https://localhost:7109/api/";

    public JobApiClient(HttpClient httpClient, ILogger<JobApiClient> logger) : base(httpClient, logger)
		{
		}
    
    public async Task<List<Option>> GetAllDomains()
    {
        return await GetJsonAsync<List<Option>>($"{_url}Job/domains");
    }

    public async Task<Job> GetJobByIdAsync(int id)
		{
	      return await GetJsonAsync<Job>($"{_url}Job/jobs/detail/{id}");
		}

    public async Task<List<Job>> GetJobsAsync()
    {
        return await GetJsonAsync<List<Job>>($"{_url}Job/jobs");
    }

    public async Task<List<Job>> GetJobsByFilterAsync(List<string> subdomains, bool workInTeam, bool workOnSite)
    {
        string subdomainsParam = string.Join("&", subdomains.Select(subdomain => $"subdomains={subdomain}"));
        string url = $"{_url}Job/jobsByFilter?{subdomainsParam}&workInTeam={workInTeam}&workOnSite={workOnSite}";
        List<Job> result = await GetJsonAsync<List<Job>>(url);

        return result ?? new List<Job>();
    }

    public async Task AddJob(Job job)
    {
        await PostJsonAsync<Job>($"{_url}Job/createjob", job);
    }

    public async Task DeleteJob(int id)
    {
        await DeleteJsonAsync($"{_url}Job/jobs/delete/{id}");
    }

    public async Task UpdateJobAsync(Job job)
    {
        await PutJsonAsync<Job>($"{_url}Job/jobs/update/{job.JobId}", job);
    }
		public async Task<List<string>> GetLocationsAsync()
		{
			List<string> locations = await GetJsonAsync<List<string>>($"{_url}StudyCourse/locations");
            return locations ?? new List<string>();
		}
	}
}
