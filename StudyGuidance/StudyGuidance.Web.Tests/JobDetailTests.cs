using Microsoft.JSInterop;
using Moq;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Web.Tests
{
    public class JobDetailTests
    {
        [Test]
        public async Task OnParametersSetAsync_Should_Set_Job_When_Id_Is_Valid()
        {
            // Arrange
            var jobDetail = new JobDetail();
            var jobApiClientMock = new Mock<IJobApiClient>();
            jobDetail.JobApiClient = jobApiClientMock.Object;
            var id = 123;

            // Mock the asynchronous call
            jobApiClientMock.Setup(j => j.GetJobByIdAsync(id)).ReturnsAsync(new Job());

            // Act
            await jobDetail.InitializeAsync(id);

            // Assert
            Assert.IsNotNull(jobDetail.Job);
            jobApiClientMock.Verify(j => j.GetJobByIdAsync(id), Times.Once);
        }

        [Test]
        public async Task GoBackToOverview_Should_Invoke_JSRuntime_VoidAsync()
        {
            // Arrange
            var jobDetail = new JobDetail();
            var jsRuntimeMock = new Mock<IJSRuntime>();
            jobDetail.JSRuntime = jsRuntimeMock.Object;

            // Act
            await jobDetail.GoBackToOverview();

            // Assert   
            jsRuntimeMock.Verify(j => j.InvokeVoidAsync("history.back"), Times.Once);
        }
    }
}
