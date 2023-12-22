using StudyGuidance.Domain;

namespace StudyGuidance.AppLogic
{
    public interface IRecruiterRepository
    {
        Task<IReadOnlyList<Recruiter>> GetRecruitersAsync();

        Task<Recruiter> GetRecruiterByIdAsync(int id);

        Task UpdateRecruiterAsync(Recruiter recruiter);

        Task<Recruiter> AddRecruiter(Recruiter recruiter);

        Task DeleteRecruiter(int id);
    }
}
