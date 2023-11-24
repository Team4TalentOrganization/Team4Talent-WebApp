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
            // Arrange
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

            // Act
            var result = await _repository.GetQuestionsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(2, Is.EqualTo(result.Count));
            Assert.IsTrue(result.All(q => q.Options.Any()));
        }

        [Test]
        public async Task GetDomainsAsync_ReturnsAllDomainsFromRepository()
        {
            // Arrange
            var domains = new List<Option>
            {
                new Option { OptionId = 4, Content = "Domain 1", QuestionId = 1 },
                new Option { OptionId = 5, Content = "Domain 2", QuestionId = 1 }
            };

            _dbContext.Options.AddRange(domains);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetDomainsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(2, Is.EqualTo(result.Count));
        }

        [Test]
        public async Task GetSubDomainsAsync_ReturnsAllSubDomainsFromRepository()
        {
            // Arrange
            var subDomains = new List<Option>
            {
                new Option { OptionId = 6, Content = "Subdomain 1", OptionRelation = 1 },
                new Option { OptionId = 7, Content = "Subdomain 2", OptionRelation = 2 }
            };

            _dbContext.Options.AddRange(subDomains);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetSubDomainsAsync(new List<int> { 1, 2 });

            // Assert
            Assert.IsNotNull(result);
            Assert.That(2, Is.EqualTo(result.Count));
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
                new Job { JobId = 1, SubDomain = "Subdomain 1", WorkInTeam = true },
                new Job { JobId = 2, SubDomain = "Subdomain 2", WorkInTeam = false },
                new Job { JobId = 3, SubDomain = "Subdomain 3", WorkInTeam = true }
            };

            bool workInTeam = true;

            _dbContext.Jobs.AddRange(jobs);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetJobsByFilterAsync(new List<string> { "Subdomain 1", "Subdomain 2" }, workInTeam);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(1, Is.EqualTo(result.Count));
            Assert.That(result.Select(job => job.SubDomain), Is.EquivalentTo(new[] { "Subdomain 1"}));
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted(); // database deleten
            _dbContext.Dispose();
        }

    }
}
