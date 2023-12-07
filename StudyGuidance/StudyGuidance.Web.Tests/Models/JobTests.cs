using NUnit.Framework;
using StudyGuidance.Web.Models;

namespace StudyGuidance.Tests.Models
{
    public class JobTests
    {
        [Test]
        public void JobProperties_DefaultValues_ShouldBeNullorFalse()
        {
            // Arrange
            var job = new Job();

            // Assert
            Assert.IsNull(job.Name);
            Assert.IsNull(job.Domain);
            Assert.IsNull(job.SubDomain);
            Assert.IsNull(job.Description);
            Assert.IsFalse(job.WorkInTeam);
            Assert.IsFalse(job.WorkOnSite);
            Assert.AreEqual(0, job.JobId);
        }

        [Test]
        public void JobProperties_SetValues_ShouldReturnCorrectValues()
        {
            // Arrange
            var job = new Job
            {
                Name = "Software Engineer",
                Domain = "IT",
                SubDomain = "Web Development",
                Description = "Exciting job in web development",
                WorkInTeam = true,
                WorkOnSite = false,
                JobId = 123
            };

            // Assert
            Assert.AreEqual("Software Engineer", job.Name);
            Assert.AreEqual("IT", job.Domain);
            Assert.AreEqual("Web Development", job.SubDomain);
            Assert.AreEqual("Exciting job in web development", job.Description);
            Assert.IsTrue(job.WorkInTeam);
            Assert.IsFalse(job.WorkOnSite);
            Assert.AreEqual(123, job.JobId);
        }
    }
}

