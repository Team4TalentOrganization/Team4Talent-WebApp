using Microsoft.AspNetCore.Components;
using StudyGuidance.Web.Models;
using StudyGuidance.Web.Shared;
using Bunit;

namespace StudyGuidance.Web.Tests.Shared
{
    [TestFixture]
    public class JobCardsTests
    {
        [Test]
        public void JobCards_NameIsSetCorrectly()
        {
            // Arrange
            var job = new Job
            {
                Name = "Software Developer"
            };

            using var ctx = new Bunit.TestContext();

            // Act
            var cut = ctx.RenderComponent<JobCards>(parameters => parameters
                .Add(p => p.Job, job));

            // Assert
            var renderedName = cut.Find("h6").TextContent;
            Assert.AreEqual(job.Name, renderedName);
        }
    }
}


