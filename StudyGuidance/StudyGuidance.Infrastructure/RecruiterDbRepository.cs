using Microsoft.EntityFrameworkCore;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using System.Linq;

namespace StudyGuidance.Infrastructure
{
    internal class RecruiterDbRepository: IRecruiterRepository
    {

        StudyGuidanceDbContext _context;

        public RecruiterDbRepository(StudyGuidanceDbContext context)
        {
            _context = context;
        }

        public async Task<Recruiter> AddRecruiter(Recruiter recruiter)
        {
            await _context.Recruiters.AddAsync(recruiter);
            await _context.SaveChangesAsync();
            return recruiter;
        }

        public async Task DeleteRecruiter(int id)
        {
            var recruiter = await _context.Recruiters.FindAsync(id);
            _context.Recruiters.Remove(recruiter);
            await _context.SaveChangesAsync();
        }

        public async Task<Recruiter?> GetRecruiterByIdAsync(int id)
        {
            return await _context.Recruiters.FirstAsync(r => r.RecruiterId == id);
        }

        public async Task<IReadOnlyList<Recruiter>> GetRecruitersAsync()
        {
            return await _context.Recruiters.ToListAsync<Recruiter>();
        }

        public async Task UpdateRecruiterAsync(Recruiter recruiter)
        {
            var selectedReview = await _context.Recruiters.FindAsync(recruiter.RecruiterId);
            var entry = _context.Entry(selectedReview);
            entry.CurrentValues.SetValues(recruiter);
            await _context.SaveChangesAsync();
        }
    }
}
