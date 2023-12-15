using Microsoft.EntityFrameworkCore;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Exceptions;
using StudyGuidance.Domain.Models;
using System.Linq;
using System.Text.Json.Serialization;

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

        public async Task<Job> AddJobAsync(JobRequest jobRequest)
        {
            if (!(await IsValidDomain(jobRequest.Domain)))
            {
                throw new BusinessException("Invalid domain for the job.");
            }

            if (!(await IsValidSubdomain(jobRequest.SubDomain)))
            {
                throw new BusinessException("Invalid subdomain for the job.");
            }

            var matchingOption = await _context.Options
                .Where(o => o.Content == jobRequest.SubDomain && o.OptionId > 7)
                .FirstOrDefaultAsync();

            Job job = new Job(jobRequest)
            {
                OptionRelation = matchingOption.OptionId,
                StudyCourseRelation = 1,
            };

            _context.Jobs.Add(job);
            _context.Testamonials.Add(job.Testamonial);
            await _context.SaveChangesAsync();

            return job;
        }

        public async Task<Job> ChangeJobAsync(Job job)
        {
            var existingJob = await _context.Jobs.SingleOrDefaultAsync(j => j.JobId == job.JobId);
            if (existingJob != null)
            {
                if (!(await IsValidDomain(job.Domain)))
                {
                    throw new BusinessException("Invalid domain for the job.");
                }

                if (!(await IsValidSubdomain(job.SubDomain)))
                {
                    throw new BusinessException("Invalid subdomain for the job.");
                }

                existingJob.Name = job.Name;
                existingJob.WorkInTeam = job.WorkInTeam;
                existingJob.WorkOnSite = job.WorkOnSite;
                existingJob.OptionRelation = job.OptionRelation;
                existingJob.StudyCourseRelation = job.StudyCourseRelation;
                existingJob.Testamonial = job.Testamonial;

                await _context.SaveChangesAsync();

                return existingJob;
            } else
            {
                throw new ArgumentNullException("Job not found");
            }
        }   

        public async Task<bool> DeleteJobAsync(int id)
        {
            bool jobExists = await _context.Jobs.AnyAsync(j => j.JobId == id);
            if (jobExists)
            {
                Job job = await _context.Jobs.FindAsync(id);
                _context.Jobs.Remove(job);
                _context.Testamonials.Remove(job.Testamonial);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> IsValidDomain(string domain)
        {
            return await _context.Options
                .AnyAsync(o => o.Content.ToUpper() == domain.ToUpper() && o.OptionId >= 1 && o.OptionId <= 7);
        }

        private async Task<bool> IsValidSubdomain(string subdomain)
        {
            return await _context.Options
                .AnyAsync(o => o.Content.ToUpper() == subdomain.ToUpper() && o.OptionId > 7);
        }
    }
}
