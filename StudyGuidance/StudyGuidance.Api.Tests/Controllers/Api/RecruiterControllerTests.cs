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
    public class RecruiterControllerTests
    {

        private RecruiterController _controller;
        private Mock<IRecruiterRepository> _recruiterRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _recruiterRepositoryMock = new Mock<IRecruiterRepository>();
            _controller = new RecruiterController(_recruiterRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllRecruiters_ReturnsNotFound_WhenNoRecruitersExist()
        {
            var emptyList = new List<Recruiter>();
            _recruiterRepositoryMock.Setup(repo => repo.GetRecruitersAsync()).ReturnsAsync(emptyList);

            // Act
            var result = await _controller.GetAllRecruiters();

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task GetAllRecruiters_ReturnsOk_WhenRecruitersExist()
        {
            var recruitersList = new List<Recruiter> {
                        new Recruiter { RecruiterId = 1, FirstName = "Max", LastName = "Valkenburg", Email = "max.valkenburg@gmail.com" },
                        new Recruiter { RecruiterId = 2, FirstName = "Mieszko", LastName = "Blazniak", Email = "mieszko.valkenburg@gmail.com" }
                };
            _recruiterRepositoryMock.Setup(repo => repo.GetRecruitersAsync()).ReturnsAsync(recruitersList);

            // Act
            var result = await _controller.GetAllRecruiters();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(recruitersList, Is.EqualTo(okResult.Value));
        }

        [Test]
        public async Task GetRecruiterById_ReturnsNotFound_WhenRecruiterDoesNotExist()
        {
            var notExistingRecruiter = new Recruiter();

            _recruiterRepositoryMock.Setup(repo => repo.GetRecruiterByIdAsync(3)).ReturnsAsync(notExistingRecruiter);

            // Act
            var result = await _controller.GetRecruiterById(5);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task GetRecruiterById_ReturnsOk_WhenRecruiterExists()
        {
            var recruitersList = new List<Recruiter> {
                        new Recruiter { RecruiterId = 1, FirstName = "Max", LastName = "Valkenburg", Email = "max.valkenburg@gmail.com" },
                        new Recruiter { RecruiterId = 2, FirstName = "Mieszko", LastName = "Blazniak", Email = "mieszko.valkenburg@gmail.com" }
                };

            var notExistingRecruiter = new Recruiter();

            _recruiterRepositoryMock.Setup(repo => repo.GetRecruiterByIdAsync(2)).ReturnsAsync(recruitersList[1]);

            // Act
            var result = await _controller.GetRecruiterById(2);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.That(recruitersList[1], Is.EqualTo(okResult.Value));
        }

        [Test]
        public async Task UpdateRecruiter_ReturnsNotFound_WhenRecruiterDoesNotExist()
        {
            var recruitersList = new List<Recruiter> {
                        new Recruiter { RecruiterId = 1, FirstName = "Max", LastName = "Valkenburg", Email = "max.valkenburg@gmail.com" },
                        new Recruiter { RecruiterId = 2, FirstName = "Mieszko", LastName = "Blazniak", Email = "mieszko.valkenburg@gmail.com" }
                };

            var recruiter = new Recruiter();

            _recruiterRepositoryMock.Setup(repo => repo.UpdateRecruiterAsync(recruiter));

            // Act
            var result = await _controller.UpdateRecruiter(5, recruiter);

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task CreateRecruiter_ReturnsOkResult()
        {

            var recruiterToCreate = new Recruiter
            {
                RecruiterId  = null,
                FirstName = "Mieszko",
                LastName = "B",
                Email = "mieszko.b@gmail.com",
                Company = "Fenego"
            };

            // Act
            var result = await _controller.CreateRecruiter(recruiterToCreate);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task DeleteRecruiter_WithNonExistingRecruiterId_ReturnsNotFound()
        {
            _recruiterRepositoryMock.Setup(repo => repo.GetRecruiterByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Recruiter)null);

            var nonExistingRecruiterId = 999;

            // Act
            var result = await _controller.DeleteRecruiter(nonExistingRecruiterId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
            _recruiterRepositoryMock.Verify(repo => repo.DeleteRecruiter(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public async Task DeleteRecruiter_WithExistingRecruiterId_ReturnsOkResult()
        {
            _recruiterRepositoryMock.Setup(repo => repo.GetRecruiterByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Recruiter { RecruiterId = 1 });

            var existingRecruiterId = 1;

            // Act
            var result = await _controller.DeleteRecruiter(existingRecruiterId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            _recruiterRepositoryMock.Verify(repo => repo.DeleteRecruiter(existingRecruiterId), Times.Once);
        }
    }
}
