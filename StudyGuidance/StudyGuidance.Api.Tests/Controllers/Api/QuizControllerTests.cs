using Moq;
using StudGuidance.Api.Controllers;
using StudyGuidance.AppLogic;
using Microsoft.AspNetCore.Mvc;
using StudyGuidance.Domain;
using StudyGuidance.Infrastructure.Migrations;
using StudyGuidance.Domain.Tests.Builders;
using System.Collections.Generic;

namespace StudyGuidance.Api.Tests.Controllers.Api
{
    public class QuizControllerTests
    {

        private QuizController _controller;
        private Mock<IQuizRepository> _questionRepositoryMock;
        private Mock<IQuestionModificationService> _questionModificationServiceMock;

        [SetUp]
        public void SetUp()
        {
            _questionRepositoryMock = new Mock<IQuizRepository>();
            _questionModificationServiceMock = new Mock<IQuestionModificationService>();
            _controller = new QuizController(_questionRepositoryMock.Object, _questionModificationServiceMock.Object);
        }

        [Test]
        public async Task GetAllQuestions_ReturnsOkWithQuestions()
        {
            var questions = new List<Question>
            {
                new QuestionBuilder().Build(),
                new QuestionBuilder().Build(),
            };
            _questionRepositoryMock.Setup(repo => repo.GetQuestionsAsync()).ReturnsAsync(questions);

            _questionModificationServiceMock.Setup(service => service.ModifyQuestions(It.IsAny<List<Question>>())).Returns<List<Question>>(inputQuestions => inputQuestions);

            var result = await _controller.GetAllQuestions();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(questions, Is.EqualTo(okResult.Value));
        }

        [Test]
        public async Task GetAllDomains_ReturnsOkWithDomains()
        {
            var domains = new List<Option> 
            {
                new OptionBuilder().Build(),
                new OptionBuilder().Build()
            };
            _questionRepositoryMock.Setup(repo => repo.GetDomainsAsync()).ReturnsAsync(domains);

            var result = await _controller.GetAllDomains();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(domains, Is.EqualTo(okResult.Value));
        }

        [Test]
        public async Task GetAllSubDomains_WithValidDomainIds_ReturnsOkWithSubDomains()
        {
            var domainIds = new List<int> { 1, 2 };
            var subDomains = new List<Question>
            {
                new QuestionBuilder().WithQuestionId(domainIds[0]).Build(),
                new QuestionBuilder().WithQuestionId(domainIds[1]).Build(),
            };
            _questionRepositoryMock.Setup(repo => repo.GetSelectedSubDomainsAsync(domainIds)).ReturnsAsync(subDomains);
            _questionModificationServiceMock.Setup(service => service.ModifyQuestions(It.IsAny<List<Question>>())).Returns<List<Question>>(inputQuestions => inputQuestions);

            var result = await _controller.GetAllSubDomains(domainIds);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(subDomains, Is.EqualTo(okResult.Value));
        }

        [Test]
        public async Task GetAllSubDomains_WithInvalidDomainIds_ReturnsNotFound()
        {
            var invalidDomainIds = new List<int> { 3, 4 };
            var subDomains = new List<Question> { };
            _questionRepositoryMock.Setup(repo => repo.GetSelectedSubDomainsAsync(invalidDomainIds)).ReturnsAsync(subDomains);
            _questionModificationServiceMock.Setup(service => service.ModifyQuestions(It.IsAny<List<Question>>())).Returns<List<Question>>(inputQuestions => inputQuestions);

            var result = await _controller.GetAllSubDomains(invalidDomainIds);

            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task GetAllQuestions_ReturnsNotFound_WhenNoQuestionsExist()
        {
            var emptyList = new List<Question>();
            _questionRepositoryMock.Setup(repo => repo.GetQuestionsAsync()).ReturnsAsync(emptyList);
            _questionModificationServiceMock.Setup(service => service.ModifyQuestions(It.IsAny<List<Question>>())).Returns<List<Question>>(inputQuestions => inputQuestions);

            // Act
            var result = await _controller.GetAllQuestions();

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task GetAllDomains_ReturnsNotFound_WhenNoDomainsExist()
        {
            var emptyList = new List<Option>();
            _questionRepositoryMock.Setup(repo => repo.GetDomainsAsync()).ReturnsAsync(emptyList);

            // Act
            var result = await _controller.GetAllDomains();

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }
    }
}
