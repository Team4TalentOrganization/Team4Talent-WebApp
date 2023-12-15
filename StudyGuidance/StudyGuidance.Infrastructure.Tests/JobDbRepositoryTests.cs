using Microsoft.EntityFrameworkCore;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Exceptions;
using StudyGuidance.Domain.Models;
using StudyGuidance.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Infrastructure.Tests
{
    public class JobDbRepositoryTests
    {
        private JobDbRepository _repository;
        private StudyGuidanceDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<StudyGuidanceDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryStudyGuidanceDb")
                .Options;

            _dbContext = new StudyGuidanceDbContext(options);
            _repository = new JobDbRepository(_dbContext);
        }

        [Test]
        public async Task GetJobsAsync_ReturnsAllJobsFromRepository()
        {
            var jobs = new List<Job>
            {
                new Job { JobId = 1, SubDomain = "Subdomain 1" },
                new Job { JobId = 2, SubDomain = "Subdomain 2" },
                new Job { JobId = 3, SubDomain = "Subdomain 3" }
            };
            _dbContext.Jobs.AddRange(jobs);
            _dbContext.SaveChanges();

            var result = await _repository.GetJobsAsync();

            Assert.IsNotNull(result);
            Assert.That(3, Is.EqualTo(result.Count));
        }

        [Test]
        public async Task GetJobsByFilterAsync_ReturnsAllRequestedJobsFromRepository()
        {
            var jobs = new List<Job>
            {
                new Job { JobId = 1, OptionRelation = 5, SubDomain = "Subdomain 1", WorkInTeam = true, WorkOnSite = true },
                new Job { JobId = 2, OptionRelation = 6, SubDomain = "Subdomain 2", WorkInTeam = false, WorkOnSite = false },
                new Job { JobId = 3, OptionRelation = 7, SubDomain = "Subdomain 3", WorkInTeam = true, WorkOnSite = false }
            };

            bool workInTeam = true;
            bool workOnSite = true;

            _dbContext.Jobs.AddRange(jobs);
            _dbContext.SaveChanges();

            var result = await _repository.GetJobsByFilterAsync(new List<int> { 5, 6 }, workInTeam, workOnSite);

            Assert.IsNotNull(result);
            Assert.That(1, Is.EqualTo(result.Count));
            Assert.That(result.Select(job => job.SubDomain), Is.EquivalentTo(new[] { "Subdomain 1" }));
        }

        [Test]
        public async Task GetJobByIdAsync_ReturnsCorrectJob()
        {
            var job = new Job { JobId = 1, Name = "Test Job" };
            _dbContext.Jobs.Add(job);
            _dbContext.SaveChanges();

            var result = await _repository.GetJobByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(job.JobId, result.JobId);
            Assert.AreEqual(job.Name, result.Name);
        }

        [Test]
        public void AddJobAsync_InvalidDomain_ThrowsBusinessException()
        {
            var jobRequest = new JobRequest
            {
                Domain = "InvalidDomain",
                SubDomain = "ValidSubDomain",
            };

            Assert.ThrowsAsync<BusinessException>(async () => await _repository.AddJobAsync(jobRequest));
        }

        [Test]
        public async Task ChangeJobAsync_InvalidDomain_ThrowsBusinessException()
        {
            var job = new Job
            {
                JobId = 1,
                Name = "OriginalName",
                Domain = "OriginalDomain",
                SubDomain = "OriginalSubDomain",
                WorkInTeam = true,
                WorkOnSite = false,
                OptionRelation = 1,
                StudyCourseRelation = 1,
                Testamonial = new Testamonial
                {
                    Name = "OriginalTestimonial",
                    Description = "OriginalTestimonialDescription",
                    JobTitel = "OriginalTestimonialTitle"
                }
            };

            _dbContext.Jobs.Add(job);
            await _dbContext.SaveChangesAsync();

            var updatedJob = new Job
            {
                JobId = 1,
                Name = "UpdatedName",
                Domain = "InvalidDomain",
                SubDomain = "UpdatedSubDomain",
                WorkInTeam = false,
                WorkOnSite = true,
                OptionRelation = 2,
                StudyCourseRelation = 2,
                Testamonial = new Testamonial
                {
                    Name = "UpdatedTestimonial",
                    Description = "UpdatedTestimonialDescription",
                    JobTitel = "UpdatedTestimonialTitle"
                }
            };

            Assert.ThrowsAsync<BusinessException>(() => _repository.ChangeJobAsync(updatedJob));
        }

        [Test]
        public async Task ChangeJobAsync_InvalidSubdomain_ThrowsBusinessException()
        {
            var job = new Job
            {
                JobId = 1,
                Name = "OriginalName",
                Domain = "OriginalDomain",
                SubDomain = "OriginalSubDomain",
                WorkInTeam = true,
                WorkOnSite = false,
                OptionRelation = 1,
                StudyCourseRelation = 1,
                Testamonial = new Testamonial
                {
                    Name = "OriginalTestimonial",
                    Description = "OriginalTestimonialDescription",
                    JobTitel = "OriginalTestimonialTitle"
                }
            };

            _dbContext.Jobs.Add(job);
            await _dbContext.SaveChangesAsync();

            var updatedJob = new Job
            {
                JobId = 1,
                Name = "UpdatedName",
                Domain = "UpdatedDomain",
                SubDomain = "InvalidSubDomain",
                WorkInTeam = false,
                WorkOnSite = true,
                OptionRelation = 2,
                StudyCourseRelation = 2,
                Testamonial = new Testamonial
                {
                    Name = "UpdatedTestimonial",
                    Description = "UpdatedTestimonialDescription",
                    JobTitel = "UpdatedTestimonialTitle"
                }
            };

            Assert.ThrowsAsync<BusinessException>(() => _repository.ChangeJobAsync(updatedJob));
        }

        [Test]
        public async Task DeleteJobAsync_JobExists_ReturnsTrueAndDeletesJob()
        {
            var job = new Job
            {
                JobId = 1,
                Name = "OriginalName",
                Domain = "OriginalDomain",
                SubDomain = "OriginalSubDomain",
                WorkInTeam = true,
                WorkOnSite = false,
                OptionRelation = 1,
                StudyCourseRelation = 1,
                Testamonial = new Testamonial
                {
                    Name = "OriginalTestimonial",
                    Description = "OriginalTestimonialDescription",
                    JobTitel = "OriginalTestimonialTitle"
                }
            };

            _dbContext.Jobs.Add(job);
            await _dbContext.SaveChangesAsync();

            var result = await _repository.DeleteJobAsync(1);

            Assert.IsTrue(result);
            Assert.AreEqual(0, _dbContext.Jobs.Count());
        }

        [Test]
        public async Task DeleteJobAsync_JobDoesNotExist_ReturnsFalse()
        {
            var result = await _repository.DeleteJobAsync(1);

            Assert.IsFalse(result);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
