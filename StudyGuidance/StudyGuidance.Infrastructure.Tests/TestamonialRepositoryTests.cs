using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyGuidance.Domain;
using StudyGuidance.Infrastructure;
using StudyGuidance.Domain.Models;

namespace StudyGuidance.Infrastructure.Tests
{
    [TestFixture]
    public class TestamonialRepositoryTests
    {
        private TestamonialRepository _repository;
        private StudyGuidanceDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<StudyGuidanceDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryStudyGuidanceDb")
                .Options;

            _dbContext = new StudyGuidanceDbContext(options);
            _repository = new TestamonialRepository(_dbContext);
        }

        [Test]
        public async Task ChangeTestimonial_ValidTestimonial_ReturnsUpdatedTestimonial()
        {
            var originalTestimonial = new Testamonial
            {
                Id = 1,
                JobId = 1,
                JobTitel = "OriginalJobTitle",
                Description = "OriginalDescription",
                Name = "OriginalName"
            };

            _dbContext.Testamonials.Add(originalTestimonial);
            await _dbContext.SaveChangesAsync();

            var updatedTestimonialDTO = new TestimonialDTO
            {
                Id = 1,
                JobId = 1,
                JobTitel = "UpdatedJobTitle",
                Description = "UpdatedDescription",
                Name = "UpdatedName"
            };

            var result = await _repository.ChangeTestimonial(updatedTestimonialDTO);

            Assert.IsNotNull(result);
            Assert.AreEqual(updatedTestimonialDTO.JobId, result.JobId);
            Assert.AreEqual(updatedTestimonialDTO.JobTitel, result.JobTitel);
            Assert.AreEqual(updatedTestimonialDTO.Description, result.Description);
            Assert.AreEqual(updatedTestimonialDTO.Name, result.Name);
        }

        [Test]
        public async Task ChangeTestimonial_InvalidTestimonial_ThrowsArgumentNullException()
        {
            var updatedTestimonialDTO = new TestimonialDTO
            {
                Id = 1,
                JobId = 1,
                JobTitel = "UpdatedJobTitle",
                Description = "UpdatedDescription",
                Name = "UpdatedName"
            };

            Assert.ThrowsAsync<ArgumentNullException>(() => _repository.ChangeTestimonial(updatedTestimonialDTO));
        }

        [Test]
        public async Task GetAllTestamonials_ReturnsAllTestamonials()
        {
            var testamonials = new List<Testamonial>
            {
                new Testamonial { Id = 1, JobId = 1, JobTitel = "JobTitle1", Description = "Description1", Name = "Name1" },
                new Testamonial { Id = 2, JobId = 2, JobTitel = "JobTitle2", Description = "Description2", Name = "Name2" },
            };

            _dbContext.Testamonials.AddRange(testamonials);
            await _dbContext.SaveChangesAsync();

            var result = await _repository.GetAllTestamonials();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task GetTestamonialByJobId_ValidJobId_ReturnsTestamonial()
        {
            var testamonial = new Testamonial { Id = 1, JobId = 1, JobTitel = "JobTitle", Description = "Description", Name = "Name" };

            _dbContext.Testamonials.Add(testamonial);
            await _dbContext.SaveChangesAsync();

            var result = await _repository.GetTestamonialByJobId(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.JobId);
            Assert.AreEqual("JobTitle", result.JobTitel);
            Assert.AreEqual("Description", result.Description);
            Assert.AreEqual("Name", result.Name);
        }

        [Test]
        public async Task GetTestamonialByJobId_InvalidJobId_ThrowsInvalidOperationException()
        {
            Assert.ThrowsAsync<InvalidOperationException>(() => _repository.GetTestamonialByJobId(1));
        }

        [Test]
        public async Task GetTestimonialById_ValidId_ReturnsTestimonial()
        {
            var testimonial = new Testamonial { Id = 1, JobId = 1, JobTitel = "JobTitle", Description = "Description", Name = "Name" };

            _dbContext.Testamonials.Add(testimonial);
            await _dbContext.SaveChangesAsync();

            var result = await _repository.GetTestimonialById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("JobTitle", result.JobTitel);
            Assert.AreEqual("Description", result.Description);
            Assert.AreEqual("Name", result.Name);
        }

        [Test]
        public async Task GetTestimonialById_InvalidId_ReturnsNull()
        {
            var result = await _repository.GetTestimonialById(1);

            Assert.IsNull(result);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
