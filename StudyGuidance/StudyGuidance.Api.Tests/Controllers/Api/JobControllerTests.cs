using Moq;
using StudGuidance.Api.Controllers;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Api.Tests.Controllers.Api
{
    public class JobControllerTests
    {

        private JobController _controller;
        private Mock<IJobRepository> _jobRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _jobRepositoryMock = new Mock<IJobRepository>();
            _controller = new JobController(_jobRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllJobs_ReturnsNotFound_WhenNoJobsExist()
        {
            var emptyList = new List<Job>();
            _jobRepositoryMock.Setup(repo => repo.GetJobsAsync()).ReturnsAsync(emptyList);

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
            _jobRepositoryMock.Setup(repo => repo.GetJobsAsync()).ReturnsAsync(jobsList);

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
            List<int> invalidSubDomainIds = new List<int> { 100, 101 };
            bool workInTeam = false;
            bool workOnSite = false;
            var jobs = new List<Job>
            {
                new Job { JobId = 1, OptionRelation = 11, Name = "Job 1", SubDomain = "Fullstack", WorkInTeam = false, WorkOnSite = false },
                new Job { JobId = 2, OptionRelation = 12, Name = "Job 2", SubDomain = "Frontend", WorkInTeam = false, WorkOnSite = false },
                new Job { JobId = 3, OptionRelation = 13, Name = "Job 3", SubDomain = "Backend", WorkInTeam = false, WorkOnSite = false },
            };

            var selectedJobs = jobs.Where(job => invalidSubDomainIds.Contains(job.OptionRelation)).ToList();

            _jobRepositoryMock.Setup(repo => repo.GetJobsByFilterAsync(invalidSubDomainIds, workInTeam, workOnSite)).ReturnsAsync(selectedJobs);

            var result = await _controller.GetAllJobsByFilter(invalidSubDomainIds, workInTeam, workOnSite);

            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task GetAllJobsByFilter_ReturnsOk_WhenJobsExistWithRequestedFilter()
        {
            var validSubDomainIds = new List<int> { 11, 12 };
            bool workInTeam = false;
            bool workOnSite = false;

            var jobs = new List<Job>
            {
                new Job { JobId = 1, OptionRelation = 11, Name = "Job 1", SubDomain = "Fullstack", WorkInTeam = false, WorkOnSite = false },
                new Job { JobId = 2, OptionRelation = 12, Name = "Job 2", SubDomain = "Frontend", WorkInTeam = false, WorkOnSite = false },
                new Job { JobId = 3, OptionRelation = 13, Name = "Job 3", SubDomain = "Backend", WorkInTeam = false, WorkOnSite = false },
            };

            var selectedJobs = jobs.Where(job => validSubDomainIds.Contains(job.OptionRelation)).ToList();

            _jobRepositoryMock.Setup(repo => repo.GetJobsByFilterAsync(validSubDomainIds, workInTeam, workOnSite)).ReturnsAsync(selectedJobs);

            var result = await _controller.GetAllJobsByFilter(validSubDomainIds, workInTeam, workOnSite);

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.That(selectedJobs, Is.EqualTo(okResult.Value));
        }
    }
}
