using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Moq;
using StudyGuidance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Infrastructure.Tests
{
    public class QuizDbRepositoryTests
    {
        private QuizDbRepository _repository;
        private StudyGuidanceDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<StudyGuidanceDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryStudyGuidanceDb")
                .Options;

            _dbContext = new StudyGuidanceDbContext(options);
            _repository = new QuizDbRepository(_dbContext);
        }

        [Test]
        public async Task GetQuestionsAsync_ReturnsAllQuestionsWithOptions()
        {
            var questions = new List<Question>
            {
                new Question { QuestionId = 1, Phrase = "Question 1" },
                new Question { QuestionId = 2, Phrase = "Question 2" }
            };

            var options = new List<Option>
            {
                new Option { OptionId = 1, Content = "Option 1", QuestionId = 1 },
                new Option { OptionId = 2, Content = "Option 2", QuestionId = 1 },
                new Option { OptionId = 3, Content = "Option 3", QuestionId = 2 }
            };

            _dbContext.Questions.AddRange(questions);
            _dbContext.Options.AddRange(options);
            _dbContext.SaveChanges();

            var result = await _repository.GetQuestionsAsync();

            Assert.IsNotNull(result);
            Assert.That(2, Is.EqualTo(result.Count));
            Assert.IsTrue(result.All(q => q.Options.Any()));
        }

        [Test]
        public async Task GetDomainsAsync_ReturnsAllDomainsFromRepository()
        {
            var domains = new List<Option>
            {
                new Option { OptionId = 4, Content = "Domain 1", QuestionId = 1 },
                new Option { OptionId = 5, Content = "Domain 2", QuestionId = 1 }
            };

            _dbContext.Options.AddRange(domains);
            _dbContext.SaveChanges();

            var result = await _repository.GetDomainsAsync();

            Assert.IsNotNull(result);
            Assert.That(2, Is.EqualTo(result.Count));
        }

        [Test]
        public async Task GetSubDomainsAsync_ReturnsAllSubDomainsFromRepository()
        {
            var subDomains = new List<Option>
            {
                new Option { OptionId = 6, Content = "Subdomain 1", OptionRelation = 1 },
                new Option { OptionId = 7, Content = "Subdomain 2", OptionRelation = 2 }
            };

            _dbContext.Options.AddRange(subDomains);
            _dbContext.SaveChanges();

            var result = await _repository.GetSubDomainsAsync(new List<int> { 1, 2 });

            Assert.IsNotNull(result);
            Assert.That(2, Is.EqualTo(result.Count));
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
                new Job { JobId = 1, SubDomain = "Subdomain 1", WorkInTeam = true, WorkOnSite = true },
                new Job { JobId = 2, SubDomain = "Subdomain 2", WorkInTeam = false, WorkOnSite = false },
                new Job { JobId = 3, SubDomain = "Subdomain 3", WorkInTeam = true, WorkOnSite = false }
            };

            bool workInTeam = true;
            bool workOnSite = true;

            _dbContext.Jobs.AddRange(jobs);
            _dbContext.SaveChanges();

            var result = await _repository.GetJobsByFilterAsync(new List<string> { "Subdomain 1", "Subdomain 2" }, workInTeam, workOnSite);

            Assert.IsNotNull(result);
            Assert.That(1, Is.EqualTo(result.Count));
            Assert.That(result.Select(job => job.SubDomain), Is.EquivalentTo(new[] { "Subdomain 1"}));
        }

        [Test]
        public async Task GetJobByIdAsync_ExistingJob_ReturnsJob()
        {
            var job = new Job { JobId = 1, Name = "Fake Job" };
            _dbContext.Jobs.Add(job);
            _dbContext.SaveChanges();

            var result = await _repository.GetJobByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Job>(result);
            Assert.AreEqual(job, result);
        }

        [Test]
        public async Task GetJobByIdAsync_NonExistingJob_ReturnsNull()
        {

            var result = await _repository.GetJobByIdAsync(999);

            Assert.IsNull(result);
        }

        [Test]
        public async Task GetJobByIdAsync_ExistingJob_ReturnsCorrectStatusCode()
        {
            var job = new Job { JobId = 1, Name = "Fake Job" };
            _dbContext.Jobs.Add(job);
            _dbContext.SaveChanges();

            var result = await _repository.GetJobByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Job>(result);
            Assert.AreEqual(1, result.JobId);
        }

        [Test]
        public async Task GetJobByIdAsync_NonExistingJob_ReturnsCorrectStatusCode()
        {
            var result = await _repository.GetJobByIdAsync(999);

            Assert.IsNull(result);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

    }
}
