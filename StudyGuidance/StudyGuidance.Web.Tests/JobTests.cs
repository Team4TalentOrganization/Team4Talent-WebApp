using Microsoft.Extensions.Logging;
using Moq.Protected;
using Moq;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGuidance.Web.Tests
{
	public class JobTests
	{
		[Test]
		public void Job_SetName_NameHasBeenSet()
		{
			// Arrange
			var job = new Job();
			string expectedName = "Software Engineer";

			// Act
			job.Name = expectedName;

			// Assert
			Assert.AreEqual(expectedName, job.Name);
		}

		[Test]
		public void Job_SetDomain_DomainHasBeenSet()
		{
			// Arrange
			var job = new Job();
			string expectedDomain = "IT";

			// Act
			job.Domain = expectedDomain;

			// Assert
			Assert.AreEqual(expectedDomain, job.Domain);
		}

		[Test]
		public void Job_SetSubDomain_SubDomainHasBeenSet()
		{
			// Arrange
			var job = new Job();
			string expectedSubDomain = "Web Development";

			// Act
			job.SubDomain = expectedSubDomain;

			// Assert
			Assert.AreEqual(expectedSubDomain, job.SubDomain);
		}

		[Test]
		public void Job_SetDescription_DescriptionHasBeenSet()
		{
			// Arrange
			var job = new Job();
			string expectedDescription = "Exciting opportunities in software development";

			// Act
			job.Description = expectedDescription;

			// Assert
			Assert.AreEqual(expectedDescription, job.Description);
		}

		[Test]
		public void Job_SetWorkInTeam_WorkInTeamHasBeenSet()
		{
			// Arrange
			var job = new Job();
			bool expectedWorkInTeam = true;

			// Act
			job.WorkInTeam = expectedWorkInTeam;

			// Assert
			Assert.AreEqual(expectedWorkInTeam, job.WorkInTeam);
		}

		[Test]
		public void Job_SetWorkOnSite_WorkOnSiteHasBeenSet()
		{
			// Arrange
			var job = new Job();
			bool expectedWorkOnSite = false;

			// Act
			job.WorkOnSite = expectedWorkOnSite;

			// Assert
			Assert.AreEqual(expectedWorkOnSite, job.WorkOnSite);
		}

		[Test]
		public void Job_SetJobId_JobIdHasBeenSet()
		{
			// Arrange
			var job = new Job();
			int expectedJobId = 123;

			// Act
			job.JobId = expectedJobId;

			// Assert
			Assert.AreEqual(expectedJobId, job.JobId);
		}
	}
}
