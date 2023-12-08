using Microsoft.EntityFrameworkCore;
using StudyGuidance.Domain;
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
            // Arrange
            var jobs = new List<Job>
            {
                new Job { JobId = 1, SubDomain = "Subdomain 1" },
                new Job { JobId = 2, SubDomain = "Subdomain 2" },
                new Job { JobId = 3, SubDomain = "Subdomain 3" }
            };
            _dbContext.Jobs.AddRange(jobs);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetJobsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(3, Is.EqualTo(result.Count));
        }

        [Test]
        public async Task GetJobsByFilterAsync_ReturnsAllRequestedJobsFromRepository()
        {
            // Arrange
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

            // Act
            var result = await _repository.GetJobsByFilterAsync(new List<int> { 5, 6 }, workInTeam, workOnSite);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(3, Is.EqualTo(result.Count));
            Assert.That(result.Select(job => job.SubDomain), Is.EquivalentTo(new[] { "Subdomain 1" }));
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted(); // database deleten
            _dbContext.Dispose();
        }
    }
}
