using Microsoft.EntityFrameworkCore;

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
            Assert.That(25, Is.EqualTo(optionsList.Count)); // verander de count naargelang je de seeddata aanpast
            Assert.IsTrue(optionsList.Any(o => o.Content == "AI"));
            Assert.IsTrue(optionsList.Any(o => o.Content == "Fullstack"));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted(); // database deleten
            _context.Dispose();
        }
    }
}
