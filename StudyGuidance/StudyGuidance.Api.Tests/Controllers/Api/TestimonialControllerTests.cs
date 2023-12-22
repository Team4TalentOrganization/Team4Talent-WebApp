using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using StudGuidance.Domain.Models;
using StudyGuidance.AppLogic;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudGuidance.Api.Controllers;

namespace StudGuidance.Api.Tests.Controllers.Api
{
    [TestFixture]
    public class TestimonialControllerTests
    {
        private TestimonialController _controller;
        private Mock<ITestamonialRepository> _testimonialRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _testimonialRepositoryMock = new Mock<ITestamonialRepository>();
            _controller = new TestimonialController(_testimonialRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllTestimonials_ReturnsOkWithTestimonials()
        {
            var testimonials = new List<Testamonial>
            {
                new Testamonial { Id = 1, Name = "John Doe", Description = "Great experience" },
                new Testamonial { Id = 2, Name = "Jane Smith", Description = "Excellent service" }
            };

            _testimonialRepositoryMock.Setup(repo => repo.GetAllTestamonials()).ReturnsAsync(testimonials);

            // Act
            var result = await _controller.GetAllTestimonials();

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<List<TestimonialDTO>>(okResult.Value);
        }

        [Test]
        public async Task GetTestimonialById_ReturnsOkWithTestimonial()
        {
            int testimonialId = 1;
            var testimonial = new Testamonial { Id = testimonialId, Name = "John Doe", Description = "Great experience" };
            _testimonialRepositoryMock.Setup(repo => repo.GetTestimonialById(testimonialId)).ReturnsAsync(testimonial);

            var result = await _controller.GetTestimonialById(testimonialId);

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<TestimonialDTO>(okResult.Value);
        }

        [Test]
        public async Task GetTestimonialById_ReturnsNotFoundWhenTestimonialIsNull()
        {
            int testimonialId = 1;
            _testimonialRepositoryMock.Setup(repo => repo.GetTestimonialById(testimonialId)).ReturnsAsync(null as Testamonial);

            var result = await _controller.GetTestimonialById(testimonialId);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task UpdateTestimonial_ReturnsOkWithUpdatedTestimonial()
        {
            var testimonialDTO = new TestimonialDTO { Id = 1, Name = "Updated Name", Description = "Updated description" };
            var updatedTestimonial = new Testamonial { Id = testimonialDTO.Id, Name = testimonialDTO.Name, Description = testimonialDTO.Description };
            _testimonialRepositoryMock.Setup(repo => repo.ChangeTestimonial(testimonialDTO)).ReturnsAsync(updatedTestimonial);

            var result = await _controller.UpdateTestimonial(testimonialDTO);
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<TestimonialDTO>(okResult.Value);
        }

        [Test]
        public async Task UpdateTestimonial_ReturnsNotFoundWhenTestimonialDTOIsNull()
        {
            TestimonialDTO testimonialDTO = null;
            var result = await _controller.UpdateTestimonial(testimonialDTO);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}

