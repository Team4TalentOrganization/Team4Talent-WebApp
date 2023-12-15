using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace StudyGuidance.Web.Tests
{
    public class QuizApiClientTests
    {
        [Test]
        public async Task GetAllDomainQuestions_ShouldReturnListOfQuestions()
        {
            // Arrange
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<System.Threading.CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{ \"questionId\": 1, \"text\": \"Sample question\" }]")
                });

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var loggerMock = new Mock<ILogger<BaseApiClient>>();

            var quizApiClient = new QuizApiClient(httpClient, loggerMock.Object);

            // Act
            var result = await quizApiClient.GetAllDomainQuestions();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Question>>(result);
        }

        [Test]
        public async Task GetJobsByFilterAsync_ShouldReturnListOfJobs()
        {
            // Arrange
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<System.Threading.CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{ \"jobId\": 1, \"title\": \"Sample job\" }]")
                });

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var loggerMock = new Mock<ILogger<JobApiClient>>();

            var jobApiClient = new JobApiClient(httpClient, loggerMock.Object);

            // Act
            var result = await jobApiClient.GetJobsByFilterAsync(new List<string> { "subdomain1", "subdomain2" }, true, false);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Job>>(result);
        }

    }
}
