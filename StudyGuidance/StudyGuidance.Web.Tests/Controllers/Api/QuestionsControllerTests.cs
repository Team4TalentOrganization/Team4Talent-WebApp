using Moq;
using StudGuidance.Api.Controllers;
using StudyGuidance.AppLogic;
using Microsoft.AspNetCore.Mvc;
using StudyGuidance.Domain;

namespace StudyGuidance.Web.Tests.Controllers.Api
{
    public class QuestionsControllerTests
    {

        private QuestionsController _controller;
        private Mock<IQuestionRepository> _questionRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _controller = new QuestionsController(_questionRepositoryMock.Object);
        }

        [Test]
        public async Task GetAll_ReturnsAllQuestionsFromRepository()
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

        private Question CreateDummyQuestion()
        {
            var domainQuestion = new Question
            {
                Phrase = "In welk domein heb je interesse?",
                QuestionId = 1,
                Options = new List<Option>
                {
                    new Option { OptionId = 1, Content = "AI", QuestionId = 1},
                    new Option { OptionId = 2, Content = "Development", QuestionId = 1},
                    new Option { OptionId = 3, Content = "Data", QuestionId = 1}
                },
            };
            return domainQuestion;
        }
    }
}
