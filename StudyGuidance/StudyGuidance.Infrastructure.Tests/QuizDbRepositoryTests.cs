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
            var subDomains = new List<Question>
            {
                new Question
                {
                    // Assuming properties for Question (e.g., Phrase) are present
                    Phrase = "Question 1",
                    Options = new List<Option>
                    {
                        new Option { OptionId = 6, Content = "Subdomain 1", OptionRelation = 1 },
                        new Option { OptionId = 7, Content = "Subdomain 2", OptionRelation = 2 }
                    }
                },
                // Add more questions if needed
            };


            _dbContext.Questions.AddRange(subDomains);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetSelectedSubDomainsAsync(new List<int> { 1 });

            // Assert
            Assert.IsNotNull(result);
            Assert.That(1, Is.EqualTo(result.Count));
        }

        [Test]
        public async Task GetStandardQuizQuestionsAsync_ReturnsQuestionsOfTypeStandardQuiz()
        {
            // Arrange
            var questions = new List<Question>
            {
                new Question { QuestionId = 1, QuestionType = QuestionType.StandardQuizQuestion },
                new Question { QuestionId = 2, QuestionType = QuestionType.TinderQuizQuestion },
                new Question { QuestionId = 3, QuestionType = QuestionType.StandardQuizQuestion }
            };

            _dbContext.Questions.AddRange(questions);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetStandardQuizQuestionsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.All(q => q.QuestionType == QuestionType.StandardQuizQuestion), Is.True);
        }

        [Test]
        public async Task GetTinderQuizQuestionsAsync_ReturnsQuestionsOfTypeTinderQuiz()
        {
            // Arrange
            var questions = new List<Question>
            {
                new Question { QuestionId = 1, QuestionType = QuestionType.StandardQuizQuestion },
                new Question { QuestionId = 2, QuestionType = QuestionType.TinderQuizQuestion },
                new Question { QuestionId = 3, QuestionType = QuestionType.StandardQuizQuestion }
            };

            _dbContext.Questions.AddRange(questions);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetTinderQuizQuestionsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.All(q => q.QuestionType == QuestionType.TinderQuizQuestion), Is.True);
        }

        [Test]
        public async Task GetDomainQuestionsAsync_ReturnsQuestionsWithSpecifiedPhrase()
        {
            // Arrange
            var questions = new List<Question>
            {
                new Question { QuestionId = 1, Phrase = "In welk domein heb je interesse?" },
                new Question { QuestionId = 2, Phrase = "Andere vraag" },
                new Question { QuestionId = 3, Phrase = "In welk domein heb je interesse?" }
            };

            _dbContext.Questions.AddRange(questions);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetDomainQuestionsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.All(q => q.Phrase == "In welk domein heb je interesse?"), Is.True);
        }

        [Test]
        public async Task GetSelectedSubDomainsForFilterAsync_ReturnsOptionsWithQuestionIdLessThan3()
        {
            // Arrange
            var options = new List<Option>
            {
                new Option { OptionId = 1, Content = "Option 1", QuestionId = 1 },
                new Option { OptionId = 2, Content = "Option 2", QuestionId = 2 },
                new Option { OptionId = 3, Content = "Option 3", QuestionId = 3 }
            };

            _dbContext.Options.AddRange(options);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetSelectedSubDomainsForFilterAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.All(o => o.QuestionId < 3), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted(); // database deleten
            _dbContext.Dispose();
        }

    }
}
