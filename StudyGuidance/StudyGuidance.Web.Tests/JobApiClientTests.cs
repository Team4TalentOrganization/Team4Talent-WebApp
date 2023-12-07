using Microsoft.Extensions.Logging;
using Moq;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudyGuidance.Web.Tests
{
	public class JobApiClientTests
	{
		private JobApiClient _jobApiClient;
		private Mock<HttpClient> _mockHttpClient;
		private Mock<ILogger<JobApiClient>> _mockLogger;

		[SetUp]
		public void Setup()
		{
			_mockHttpClient = new Mock<HttpClient>();
			_mockLogger = new Mock<ILogger<JobApiClient>>();
			_jobApiClient = new JobApiClient(_mockHttpClient.Object, _mockLogger.Object);
		}

		[Test]
		public async Task GetAllSubDomains_ValidCall_ReturnsListOfSubDomains()
		{
			// Arrange
			var expectedSubDomains = new List<Option>
			{
				new Option
				{
					Content = "Option 1 Content",
					OptionRelation = 1,
					QuestionId = 1,
					OptionId = 1
				},
				new Option
				{
					Content = "Option 2 Content",
					OptionRelation = 2,
					QuestionId = 2,
					OptionId = 2
				},
    
			};

			_mockHttpClient.Setup(client => client.GetFromJsonAsync<List<Option>>(It.IsAny<string>()))
						   .ReturnsAsync(expectedSubDomains);

			// Act
			var result = await _jobApiClient.GetAllSubDomains();

			// Assert
			Assert.AreEqual(expectedSubDomains, result);
		}
	}
}
