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
            var subDomains = new List<Question>
            {
                new Question
                {
                    Phrase = "Question 1",
                    Options = new List<Option>
                    {
                        new Option { OptionId = 6, Content = "Subdomain 1", OptionRelation = 1 },
                        new Option { OptionId = 7, Content = "Subdomain 2", OptionRelation = 2 }
                    }
                },
            };


            _dbContext.Questions.AddRange(subDomains);
            _dbContext.SaveChanges();

            var result = await _repository.GetSelectedSubDomainsAsync(new List<int> { 1 });

            Assert.IsNotNull(result);
            Assert.That(1, Is.EqualTo(result.Count));
        }

        [Test]
        public async Task GetSelectedSubDomainsForFilterAsync_ReturnsSelectedSubDomains()
        {
            var selectedSubDomains = new List<Option>
    {
        new Option { OptionId = 8, Content = "Subdomain 3", OptionRelation = 3 },
        new Option { OptionId = 9, Content = "Subdomain 4", OptionRelation = 4 }
    };

            _dbContext.Options.AddRange(selectedSubDomains);
            _dbContext.SaveChanges();

            var result = await _repository.GetSelectedSubDomainsForFilterAsync();

            Assert.IsNotNull(result);
            Assert.That(2, Is.EqualTo(result.Count));
            Assert.IsTrue(result.All(o => o.OptionId > 7));
        }

        [Test]
        public async Task GetStandardQuizQuestionsAsync_ReturnsStandardQuizQuestions()
        {
            var standardQuizQuestions = new List<Question>
    {
        new Question { QuestionId = 1, QuestionType = QuestionType.StandardQuizQuestion, Phrase = "Standard Question 1" },
        new Question { QuestionId = 2, QuestionType = QuestionType.StandardQuizQuestion, Phrase = "Standard Question 2" }
    };

            _dbContext.Questions.AddRange(standardQuizQuestions);
            _dbContext.SaveChanges();

            var result = await _repository.GetStandardQuizQuestionsAsync();

            Assert.IsNotNull(result);
            Assert.That(2, Is.EqualTo(result.Count));
            Assert.IsTrue(result.All(q => q.QuestionType == QuestionType.StandardQuizQuestion));
        }

        [Test]
        public async Task GetTinderQuizQuestionsAsync_ReturnsTinderQuizQuestions()
        {
            var tinderQuizQuestions = new List<Question>
    {
        new Question { QuestionId = 3, QuestionType = QuestionType.TinderQuizQuestion, Phrase = "Tinder Question 1" },
        new Question { QuestionId = 4, QuestionType = QuestionType.TinderQuizQuestion, Phrase = "Tinder Question 2" }
    };

            _dbContext.Questions.AddRange(tinderQuizQuestions);
            _dbContext.SaveChanges();

            var result = await _repository.GetTinderQuizQuestionsAsync();

            Assert.IsNotNull(result);
            Assert.That(2, Is.EqualTo(result.Count));
            Assert.IsTrue(result.All(q => q.QuestionType == QuestionType.TinderQuizQuestion));
        }

        [Test]
        public async Task GetDomainQuestionsAsync_ReturnsDomainQuestions()
        {
            var domainQuestions = new List<Question>
            {
              new Question { QuestionId = 5, Phrase = "In welk domein heb je interesse?" },
              new Question { QuestionId = 6, Phrase = "Another Domain Question" }
            };

            _dbContext.Questions.AddRange(domainQuestions);
            _dbContext.SaveChanges();

            var result = await _repository.GetDomainQuestionsAsync();

            Assert.IsNotNull(result);
            Assert.That(1, Is.EqualTo(result.Count));
            Assert.That("In welk domein heb je interesse?", Is.EqualTo(result.First().Phrase));
        }



        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

    }
}
