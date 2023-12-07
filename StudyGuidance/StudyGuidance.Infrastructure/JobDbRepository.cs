using Microsoft.EntityFrameworkCore;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using System.Linq;

namespace StudyGuidance.Infrastructure
{
    internal class JobDbRepository: IJobRepository
    {

        StudyGuidanceDbContext _context;

        public JobDbRepository(StudyGuidanceDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Job>> GetJobsAsync()
        {
            return await _context.Jobs.ToListAsync<Job>();
        }

        public async Task<IReadOnlyList<Job>> GetJobsByFilterAsync(List<int> subdomainIds, bool workInTeam, bool workOnSite)
        {
            List<Job> matchingJobs = await _context.Jobs
                .Where(job => subdomainIds.Contains(job.OptionRelation) && (job.WorkInTeam == workInTeam || job.WorkOnSite == workOnSite))
                .ToListAsync();

            return matchingJobs;
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _context.Jobs.SingleOrDefaultAsync(j => j.JobId == id);
        }
    }
}
