using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.ApiClient
{
	public interface IRecruiterApiClient
    {
		Task<List<Recruiter>> GetRecruitersAsync();

        Task<Recruiter> GetRecruiterByIdAsync(int id);

        Task UpdateRecruiterAsync(Recruiter recruiter);

        Task AddRecruiter(Recruiter recruiter);

        Task DeleteRecruiter(int id);
    }
}
