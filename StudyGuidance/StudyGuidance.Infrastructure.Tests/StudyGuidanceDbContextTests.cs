using Microsoft.EntityFrameworkCore;
using StudyGuidance.Domain;

namespace StudyGuidance.Infrastructure.Tests
{
    public class StudyGuidanceDbContextTests
    {
        private StudyGuidanceDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<StudyGuidanceDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new StudyGuidanceDbContext(options);
            _context.Database.EnsureCreated();
        }

        [Test]
        public void Can_Add_And_Retrieve_Questions_From_DbContext()
        {
            var questions = _context.Questions.ToList();

            Assert.IsNotNull(questions);
            Assert.That(2, Is.EqualTo(questions.Count));
            Assert.IsTrue(questions.Any(q => q.Phrase == "In welk domein heb je interesse?"));
            Assert.IsTrue(questions.Any(q => q.Phrase == "In welk subdomein heb je interesse?"));
        }

        [Test]
        public void Can_Add_And_Retrieve_Options_From_DbContext()
        {
            var optionsList = _context.Options.ToList();
            Assert.IsNotNull(optionsList);
            Assert.That(25, Is.EqualTo(optionsList.Count));
            Assert.IsTrue(optionsList.Any(o => o.Content == "AI"));
            Assert.IsTrue(optionsList.Any(o => o.Content == "Fullstack"));
        }

        [Test]
        public void Can_Add_And_Retrieve_Jobs_From_DbContext()
        {
            // Arrange
            var jobsList = _context.Jobs.ToList();

            // Assert
            Assert.IsNotNull(jobsList);
            Assert.That(30, Is.EqualTo(jobsList.Count));
            Assert.IsTrue(jobsList.Any(j => j.Name == "Tester"));
            Assert.IsTrue(jobsList.Any(j => j.Name == "PHP Developer"));
        }

        [Test]
        public void Can_Add_And_Retrieve_Questions_Options_Relations_From_DbContext()
        {
            // Arrange
            var questionsWithOptions = _context.Questions
                .Include(q => q.Options)
                .ToList();

            // Assert
            Assert.IsNotNull(questionsWithOptions);
            Assert.That(2, Is.EqualTo(questionsWithOptions.Count));
            Assert.IsTrue(questionsWithOptions.Any(q => q.Phrase == "In welk domein heb je interesse?" && q.Options.Any()));
            Assert.IsTrue(questionsWithOptions.Any(q => q.Phrase == "In welk subdomein heb je interesse?" && q.Options.Any()));
        }

        [Test]
        public void Can_Associate_Options_With_Questions()
        {
            // Arrange
            var question = _context.Questions.First(); // Assuming at least one question exists
            var option = new Option { Content = "New Option", QuestionId = question.QuestionId };

            // Act
            _context.Options.Add(option);
            _context.SaveChanges();

            // Assert
            var updatedQuestion = _context.Questions.Include(q => q.Options).First(q => q.QuestionId == question.QuestionId);
            Assert.IsNotNull(updatedQuestion.Options);
            Assert.IsTrue(updatedQuestion.Options.Any(o => o.Content == "New Option"));
        }

        [Test]
        public void DbContext_Saves_Changes_After_Adding_Question()
        {
            // Arrange
            var initialCount = _context.Questions.Count();

            // Act
            _context.Questions.Add(new Question { Phrase = "New Question" });
            _context.SaveChanges();

            // Assert
            Assert.That(_context.Questions.Count(), Is.EqualTo(initialCount + 1));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted(); // database deleten
            _context.Dispose();
        }
    }
}
