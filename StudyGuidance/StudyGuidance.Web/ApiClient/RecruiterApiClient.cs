using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.ApiClient
{
    public class RecruiterApiClient : BaseApiClient, IRecruiterApiClient
    {

		private string _url = $"https://localhost:7109/api/";

        public RecruiterApiClient(HttpClient httpClient, ILogger<RecruiterApiClient> logger) : base(httpClient, logger)
		{
		}

        public async Task AddRecruiter(Recruiter recruiter)
        {
            await PostJsonAsync<Recruiter>($"{_url}Recruiter/createrecruiter", recruiter);
        }

        public async Task DeleteRecruiter(int id)
        {
            await DeleteJsonAsync($"{_url}Recruiter/deleterecruiter/{id}");
        }

        public async Task<Recruiter> GetRecruiterByIdAsync(int id)
        {
            return await GetJsonAsync<Recruiter>($"{_url}Recruiter/recruiter/{id}");
        }

        public async Task<List<Recruiter>> GetRecruitersAsync()
        {
            return await GetJsonAsync<List<Recruiter>>($"{_url}Recruiter/recruiters");
        }

        public async Task UpdateRecruiterAsync(Recruiter recruiter)
        {
            await PutJsonAsync($"{_url}Recruiter/updaterecruiter/{recruiter.RecruiterId}", recruiter);
        }
    }
}
