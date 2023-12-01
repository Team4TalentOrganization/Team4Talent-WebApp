using Microsoft.EntityFrameworkCore;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using System.Linq;

namespace StudyGuidance.Infrastructure
{
    internal class QuizDbRepository: IQuizRepository
    {

        StudyGuidanceDbContext _context;

        public QuizDbRepository(StudyGuidanceDbContext context)
        { 
            _context = context;
        }

        public async Task<IReadOnlyList<Question>> GetQuestionsAsync()
        {
            return await _context.Questions.Include(options => options.Options).ToListAsync<Question>();
        }

        public async Task<IReadOnlyList<Option>> GetDomainsAsync()
        {
            return await _context.Options.Where(o => o.QuestionId == 1).ToListAsync<Option>();
        }

        public async Task<IReadOnlyList<Option>> GetSubDomainsAsync(List<int> domainIds)
        {
            return await _context.Options
                .Where(o => domainIds.Contains(o.OptionRelation))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Job>> GetJobsAsync()
        {
            return await _context.Jobs.ToListAsync<Job>();
        }

        public async Task<IReadOnlyList<Job>> GetJobsByFilterAsync(List<string> subdomains, bool workInTeam, bool workOnSite)
        {
            var matchingJobs = await _context.Jobs
                .Where(job => subdomains.Contains(job.SubDomain) && job.WorkInTeam == workInTeam || job.WorkOnSite == workOnSite)
                .ToListAsync();

            return matchingJobs;
        }

		public async Task<Job> GetJobByIdAsync(int id)
		{
			return await _context.Jobs.SingleOrDefaultAsync(j => j.JobId == id);
		}
	}
}
