using StudyGuidance.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Web.Tests
{
    public class JobTests
    {
        [Test]
        public void Should_Set_Properties_Correctly()
        {
            // Arrange
            var job = new Job();

            // Act
            job.Name = "Test Job";
            job.Domain = "Test Domain";
            job.SubDomain = "Test SubDomain";
            job.Description = "Test Description";
            job.WorkInTeam = true;
            job.WorkOnSite = false;
            job.JobId = 123;

            // Assert
            Assert.AreEqual("Test Job", job.Name);
            Assert.AreEqual("Test Domain", job.Domain);
            Assert.AreEqual("Test SubDomain", job.SubDomain);
            Assert.AreEqual("Test Description", job.Description);
            Assert.IsTrue(job.WorkInTeam);
            Assert.IsFalse(job.WorkOnSite);
            Assert.AreEqual(123, job.JobId);
        }

       
    }
}
