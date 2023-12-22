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
using System.Runtime.InteropServices;
using StudGuidance.Domain.Models;
using StudyGuidance.Domain.Models;

namespace StudyGuidance.Api.Tests.Controllers.Api
{
    public class JobControllerTests
    {

        private JobController _controller;
        private Mock<IJobRepository> _jobRepositoryMock;
        private Mock<IStudyCourseRepository> _studyCourseRepositoryMock;
        private Mock<ITestamonialRepository> _testamonialRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _jobRepositoryMock = new Mock<IJobRepository>();
            _studyCourseRepositoryMock = new Mock<IStudyCourseRepository>();
            _testamonialRepositoryMock = new Mock<ITestamonialRepository>();
            _controller = new JobController(_jobRepositoryMock.Object, _studyCourseRepositoryMock.Object, _testamonialRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllJobs_ReturnsNotFound_WhenNoJobsExist()
        {
            var emptyList = new List<Job>();
            _jobRepositoryMock.Setup(repo => repo.GetJobsAsync()).ReturnsAsync(emptyList);

            var result = await _controller.GetAllJobs();

            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task GetAllJobs_ReturnsOk_WhenJobsExist()
        {
            var jobsList = new List<Job>
            {
                new Job { JobId = 1, Name = "Job 1" },
                new Job { JobId = 2, Name = "Job 2" }
            };
            _jobRepositoryMock.Setup(repo => repo.GetJobsAsync()).ReturnsAsync(jobsList);

            var result = await _controller.GetAllJobs();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(jobsList, Is.EqualTo(okResult.Value));
        }

        [Test]
        public async Task GetAllJobsByFilter_ReturnsNotFound_WhenNoJobsExistWithRequestedFilter()
        {
            var invalidSubDomainIds = new List<int> { 100, 101 };
            var workInTeam = false;
            var workOnSite = false;
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
            var workInTeam = false;
            var workOnSite = false;
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

        [Test]
        public async Task GetJobById_ReturnsNotFound_WhenJobDoesNotExist()
        {
            int jobId = 1;
            _jobRepositoryMock.Setup(repo => repo.GetJobByIdAsync(jobId)).ReturnsAsync((Job)null);

            var result = await _controller.GetJobById(jobId);
        }

        [Test]
        public async Task GetJobById_ReturnsOkWithJobDTO_WhenJobExists()
        {
            int jobId = 1;
            var job = DummyData.CreateDummyJob();
            job.JobId = jobId;

            _jobRepositoryMock.Setup(repo => repo.GetJobByIdAsync(jobId)).ReturnsAsync(job);

            var testamonial = DummyData.CreateDummyTestamonial();
            _testamonialRepositoryMock.Setup(repo => repo.GetTestamonialByJobId(jobId)).ReturnsAsync(testamonial);

            var studyCourses = new List<StudyCourse> { DummyData.CreateDummyStudyCourse() };
            _studyCourseRepositoryMock.Setup(repo => repo.GetStudyCoursesByRelationAsync(job.StudyCourseRelation)).ReturnsAsync(studyCourses);

            var result = await _controller.GetJobById(jobId);

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<JobDTO>(okResult.Value);

            var jobDTO = (JobDTO)okResult.Value;
            Assert.AreEqual(job.JobId, jobDTO.JobId);
            Assert.AreEqual(job.Name, jobDTO.Name);
        }

        [Test]
        public async Task AddJob_ReturnsNotFound_WhenJobIsNull()
        {
            _jobRepositoryMock.Setup(repo => repo.AddJobAsync(It.IsAny<JobRequest>())).ReturnsAsync((Job)null);
            var result = await _controller.AddJob(new JobRequest());
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task AddJob_ReturnsOkWithJob_WhenJobIsNotNull()
        {
            var jobRequest = new JobRequest { Name = "Software Engineer", Domain = "IT", SubDomain = "Development", Description = "Develop software applications",
                TestamonialRequest = new TestimonialRequest
                {
                    Name = "John Doe",
                    Description = "A satisfied employee",
                    JobTitel = "Senior Software Engineer"
                }
            };
            var addedJob = new Job(jobRequest);
            _jobRepositoryMock.Setup(repo => repo.AddJobAsync(jobRequest)).ReturnsAsync(addedJob);

            var result = await _controller.AddJob(jobRequest);

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<Job>(okResult.Value);

            var job = (Job)okResult.Value;
            Assert.AreEqual(addedJob.JobId, job.JobId);
            Assert.AreEqual(addedJob.Name, job.Name);
        }

        [Test]
        public async Task UpdateJob_ReturnsNotFound_WhenJobIsNull()
        {
            _jobRepositoryMock.Setup(repo => repo.ChangeJobAsync(It.IsAny<Job>())).ReturnsAsync((Job)null);
            var result = await _controller.UpdateJob(1,new Job());
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task DeleteJob_ReturnsNotFound_WhenJobIsNotDeleted()
        {
            int jobId = 1;
            _jobRepositoryMock.Setup(repo => repo.DeleteJobAsync(jobId)).ReturnsAsync(false);

            var result = await _controller.DeleteJob(jobId);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task DeleteJob_ReturnsOk_WhenJobIsDeleted()
        {
            int jobId = 1;
            _jobRepositoryMock.Setup(repo => repo.DeleteJobAsync(jobId)).ReturnsAsync(true);

            var result = await _controller.DeleteJob(jobId);
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}
