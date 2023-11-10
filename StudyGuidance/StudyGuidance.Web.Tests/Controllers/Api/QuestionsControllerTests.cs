using Moq;
using StudGuidance.Api.Controllers;
using StudyGuidance.AppLogic;
using Microsoft.AspNetCore.Mvc;
using StudyGuidance.Domain;
using StudyGuidance.Infrastructure.Migrations;

namespace StudyGuidance.Web.Tests.Controllers.Api
{
    public class QuestionsControllerTests
    {

        private QuizController _controller;
        private Mock<IQuestionRepository> _questionRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _controller = new QuizController(_questionRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllQuestions_ReturnsAllQuestionsFromRepository()
        {
            //Arange
            Question question = CreateDummyQuestion();
            List<Question> questions = new List<Question>();
            questions.Add(question);
            _questionRepositoryMock.Setup(r => r.GetQuestionsAsync()).ReturnsAsync(questions);

            //Act
            var Result = await _controller.GetAllQuestions() as OkObjectResult;

            //Assert
            Assert.That(Result, Is.Not.Null);
            Assert.That(Result.Value, Is.EquivalentTo(questions));
            _questionRepositoryMock.Verify(r => r.GetQuestionsAsync(), Times.Once);

        }

        [Test]
        public async Task GetDomains_ReturnsAllDomainsFromRepository()
        {
            //Arange
            List<Option> domains = CreateDummyDomains();
            _questionRepositoryMock.Setup(r => r.GetDomainsAsync()).ReturnsAsync(domains);

            //Act
            var Result = await _controller.GetAllDomains() as OkObjectResult;

            //Assert
            Assert.That(Result, Is.Not.Null);
            Assert.That(Result.Value, Is.EquivalentTo(domains));
            _questionRepositoryMock.Verify(r => r.GetDomainsAsync(), Times.Once);

        }

        [Test]
        public async Task GetSubDomains_ReturnsSubDomainsWithIdFromRepository()
        {
            //Arange
            List<Option> subDomains = CreateDummySubDomains();

            List<int> subDomainIds = new List<int>();
            subDomainIds.Add(1);
            subDomainIds.Add(2);

            _questionRepositoryMock.Setup(r => r.GetSubDomainsAsync(subDomainIds)).ReturnsAsync(subDomains);

            //Act
            var Result = await _controller.GetAllSubDomains(subDomainIds) as OkObjectResult;

            //Assert
            Assert.That(Result, Is.Not.Null);
            Assert.That(Result.Value, Is.EquivalentTo(subDomains));
            _questionRepositoryMock.Verify(r => r.GetSubDomainsAsync(subDomainIds), Times.Once);

        }

        private Question CreateDummyQuestion()
        {
            var domainQuestion = new Question
            {
                Phrase = "In welk domein heb je interesse?",
                QuestionId = 1,
                Options = CreateDummyDomains(),
            };
            return domainQuestion;
        }

        private List<Option> CreateDummyDomains()
        {
            List<Option> domains = new List<Option>
            {
                new Option { OptionId = 1, Content = "AI", QuestionId = 1 },
                new Option { OptionId = 2, Content = "Development", QuestionId = 1 },
                new Option { OptionId = 3, Content = "Data", QuestionId = 1 }
            };
            return domains;
        }

        private List<Option> CreateDummySubDomains()
        {
            Question question = CreateDummyQuestion();

            List<Option> subDomains = new List<Option>
            {
            new Option { OptionId = 8, Content = "AI Robotics", QuestionId = question.QuestionId, OptionRelation = 1 },
            new Option { OptionId = 9, Content = "Machine Learning", QuestionId = question.QuestionId, OptionRelation = 1 },
            new Option { OptionId = 10, Content = "Computer Vision", QuestionId = question.QuestionId, OptionRelation = 1 },
            new Option { OptionId = 11, Content = "Fullstack", QuestionId = question.QuestionId, OptionRelation = 2 },
            new Option { OptionId = 12, Content = "Frontend", QuestionId = question.QuestionId, OptionRelation = 2 },
            new Option { OptionId = 13, Content = "Backend", QuestionId = question.QuestionId, OptionRelation = 2 },
            };
            return subDomains;
        }
    }
}
