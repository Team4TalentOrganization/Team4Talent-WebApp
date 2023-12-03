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

        [Test]
        public async Task GetAllJobs_ReturnsNotFound_WhenNoJobsExist()
        {
            var emptyList = new List<Job>();
            _questionRepositoryMock.Setup(repo => repo.GetJobsAsync()).ReturnsAsync(emptyList);

            // Act
            var result = await _controller.GetAllJobs();

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task GetAllJobs_ReturnsOk_WhenJobsExist()
        {
            var jobsList = new List<Job> {
                        new Job { JobId = 1, Name = "Job 1" },
                        new Job { JobId = 2, Name = "Job 2" }
                };
            _questionRepositoryMock.Setup(repo => repo.GetJobsAsync()).ReturnsAsync(jobsList);

            // Act
            var result = await _controller.GetAllJobs();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(jobsList, Is.EqualTo(okResult.Value));
        }

        [Test]
        public async Task GetAllJobsByFilter_ReturnsNotFound_WhenNoJobsExistWithRequestedFilter()
        {
            var invalidSubDomains = new List<string> { "non existing domain", "another non existing domain" };
            bool workInTeam = false;
            bool workOnSite = false;
            var jobs = new List<Job> { };
            _questionRepositoryMock.Setup(repo => repo.GetJobsByFilterAsync(invalidSubDomains, workInTeam, workOnSite)).ReturnsAsync(jobs);

            var result = await _controller.GetAllJobsByFilter(invalidSubDomains, workInTeam, workOnSite);

            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task GetAllJobsByFilter_ReturnsOk_WhenJobsExistWithRequestedFilter()
        {
            var validSubDomains = new List<string> { "Subdomain 1", "Subdomain 2" };
            bool workInTeam = false;
            bool workOnSite = false;
            var jobs = new List<Job> {
                        new Job { JobId = 1, Name = "Job 1", SubDomain = "Subdomain 1", WorkInTeam = true, WorkOnSite = true },
                        new Job { JobId = 2, Name = "Job 2", SubDomain = "Subdomain 1", WorkInTeam = false, WorkOnSite = false }
                };
            var selectedJob = new List<Job>();
            selectedJob.Add(jobs[1]);
            _questionRepositoryMock.Setup(repo => repo.GetJobsByFilterAsync(validSubDomains, workInTeam, workOnSite)).ReturnsAsync(selectedJob);

            var result = await _controller.GetAllJobsByFilter(validSubDomains, workInTeam, workOnSite);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(selectedJob, Is.EqualTo(okResult.Value));
        }
    }
}
