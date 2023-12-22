using Moq;
using NUnit.Framework;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudGuidance.Api.Controllers;
using StudGuidance.Domain.Models;
using StudyGuidance.Domain.Models;

namespace StudyGuidance.Api.Tests.Controllers.Api
{
    [TestFixture]
    public class StudyCourseControllerTests
    {
        private StudyCourseController _controller;
        private Mock<IStudyCourseRepository> _studyCourseRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _studyCourseRepositoryMock = new Mock<IStudyCourseRepository>();
            _controller = new StudyCourseController(_studyCourseRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllLocations_ReturnsOkWithLocations()
        {
            // Arrange
            _studyCourseRepositoryMock.Setup(repo => repo.GetAllLocationsAsync()).ReturnsAsync(new List<string> { "Location1", "Location2" });

            // Act
            var result = await _controller.GetAllLocations();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<List<string>>(okResult.Value);
        }

        [Test]
        public async Task GetAllDiplomas_ReturnsOkWithDiplomas()
        {
            // Arrange
            _studyCourseRepositoryMock.Setup(repo => repo.GetAllDiplomasAsync()).ReturnsAsync(new List<string> { "Diploma1", "Diploma2" });

            // Act
            var result = await _controller.GetAllDiplomas();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<List<string>>(okResult.Value);
        }

        [Test]
        public async Task GetAllStudycourses_ReturnsOkWithStudycourses()
        {
            // Arrange
            var studyCourses = new List<StudyCourse> {
                new StudyCourse { Id = 1, School = "University 1", Study = "Computer Science" },
                new StudyCourse { Id = 2, School = "University 2", Study = "Engineering" }
            };
            _studyCourseRepositoryMock.Setup(repo => repo.GetStudyCoursesAsync()).ReturnsAsync(studyCourses);

            // Act
            var result = await _controller.GetAllStudycourses();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<List<StudyCourseDTO>>(okResult.Value);
        }

        [Test]
        public async Task GetStudycourseById_ReturnsOkWithStudycourse()
        {
            // Arrange
            int studycourseId = 1;
            var studyCourse = new StudyCourse { Id = studycourseId, School = "University", Study = "Computer Science" };
            _studyCourseRepositoryMock.Setup(repo => repo.GetStudyCourseAsync(studycourseId)).ReturnsAsync(studyCourse);

            // Act
            var result = await _controller.GetAllStudycourseById(studycourseId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<StudyCourseDTO>(okResult.Value);
        }

        [Test]
        public async Task AddStudycourse_ReturnsOkWithStudycourse_WhenStudycourseIsAdded()
        {
            // Arrange
            var studyCourseRequest = new StudyCourseRequest { School = "University", Study = "Computer Science" };
            var addedStudyCourse = new StudyCourse { Id = 1, School = studyCourseRequest.School, Study = studyCourseRequest.Study };
            _studyCourseRepositoryMock.Setup(repo => repo.AddStudyCourseAsync(studyCourseRequest)).ReturnsAsync(addedStudyCourse);

            // Act
            var result = await _controller.AddStudycourse(studyCourseRequest);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<StudyCourseDTO>(okResult.Value);
        }

        [Test]
        public async Task UpdateStudycourse_ReturnsOkWithUpdatedStudycourse_WhenStudycourseIsUpdated()
        {
            // Arrange
            var studyCourseDTO = new StudyCourseDTO { Id = 1, School = "Updated University", Study = "Updated Computer Science", Location = Location.Tournai.ToString() };
            var updatedStudyCourse = new StudyCourse { Id = studyCourseDTO.Id, School = studyCourseDTO.School, Study = studyCourseDTO.Study };
            _studyCourseRepositoryMock.Setup(repo => repo.ChangeStudyCourseAsync(studyCourseDTO)).ReturnsAsync(updatedStudyCourse);

            // Act
            var result = await _controller.UpdateStudycourse(studyCourseDTO);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<StudyCourseDTO>(okResult.Value);
        }

        [Test]
        public async Task DeleteStudycourse_ReturnsOk_WhenStudycourseIsDeleted()
        {
            // Arrange
            int studycourseId = 1;
            _studyCourseRepositoryMock.Setup(repo => repo.DeleteStudyCourseAsync(studycourseId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteStudycourse(studycourseId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task DeleteStudycourse_ReturnsNotFound_WhenStudycourseIsNotDeleted()
        {
            // Arrange
            int studycourseId = 1;
            _studyCourseRepositoryMock.Setup(repo => repo.DeleteStudyCourseAsync(studycourseId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteStudycourse(studycourseId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}

