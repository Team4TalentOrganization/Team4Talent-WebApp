using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using StudyGuidance.Domain;
using StudyGuidance.Infrastructure;
using StudyGuidance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudGuidance.Domain.Models;

namespace StudyGuidance.Infrastructure.Tests
{
    [TestFixture]
    public class StudyCourseRepositoryTests
    {
        private StudyCourseRepository _repository;
        private StudyGuidanceDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<StudyGuidanceDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryStudyGuidanceDb")
                .Options;

            _dbContext = new StudyGuidanceDbContext(options);
            _repository = new StudyCourseRepository(_dbContext);
        }

        [Test]
        public async Task GetStudyCourseAsync_ValidId_ReturnsStudyCourse()
        {
            var studyCourse = new StudyCourse
            {
                Id = 1,
                School = "School",
                Study = "Study",
                DiplomaType = Diploma.Bachelor,
                Location = Location.Hasselt,
                JobRelation = 1
            };

            _dbContext.StudyCourses.Add(studyCourse);
            await _dbContext.SaveChangesAsync();

            var result = await _repository.GetStudyCourseAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("School", result.School);
            Assert.AreEqual("Study", result.Study);
            Assert.AreEqual(Diploma.Bachelor, result.DiplomaType);
            Assert.AreEqual(Location.Hasselt, result.Location);
            Assert.AreEqual(1, result.JobRelation);
        }

        [Test]
        public async Task GetStudyCourseAsync_InvalidId_ReturnsNull()
        {
            var result = await _repository.GetStudyCourseAsync(1);

            Assert.IsNull(result);
        }

        [Test]
        public async Task AddStudyCourseAsync_ValidStudyCourse_ReturnsAddedStudyCourse()
        {
            var studyCourseRequest = new StudyCourseRequest
            {
                School = "School",
                Study = "Study",
                DiplomaType = "Bachelor",
                Location = "Hasselt",
                JobRelation = 1
            };

            var result = await _repository.AddStudyCourseAsync(studyCourseRequest);

            Assert.IsNotNull(result);
            Assert.AreEqual("School", result.School);
            Assert.AreEqual("Study", result.Study);
            Assert.AreEqual(Diploma.Bachelor, result.DiplomaType);
            Assert.AreEqual(Location.Hasselt, result.Location);
            Assert.AreEqual(1, result.JobRelation);
        }

        [Test]
        public async Task ChangeStudyCourseAsync_ValidStudyCourseDTO_ReturnsUpdatedStudyCourse()
        {
            var originalStudyCourse = new StudyCourse
            {
                Id = 1,
                School = "OriginalSchool",
                Study = "OriginalStudy",
                DiplomaType = Diploma.Bachelor,
                Location = Location.Hasselt,
                JobRelation = 1
            };

            _dbContext.StudyCourses.Add(originalStudyCourse);
            await _dbContext.SaveChangesAsync();

            var updatedStudyCourseDTO = new StudyCourseDTO
            {
                Id = 1,
                School = "UpdatedSchool",
                Study = "UpdatedStudy",
                DiplomaType = "Master",
                Location = "Hasselt",
                JobRelation = 2
            };

            var result = await _repository.ChangeStudyCourseAsync(updatedStudyCourseDTO);

            Assert.IsNotNull(result);
            Assert.AreEqual("UpdatedSchool", result.School);
            Assert.AreEqual("UpdatedStudy", result.Study);
            Assert.AreEqual(Diploma.Master, result.DiplomaType);
            Assert.AreEqual(Location.Hasselt, result.Location);
            Assert.AreEqual(2, result.JobRelation);
        }

        [Test]
        public async Task ChangeStudyCourseAsync_InvalidStudyCourseDTO_ThrowsArgumentException()
        {
            var updatedStudyCourseDTO = new StudyCourseDTO
            {
                Id = 1,
                School = "UpdatedSchool",
                Study = "UpdatedStudy",
                DiplomaType = "InvalidDiploma",
                Location = "InvalidLocation",
                JobRelation = 2
            };

            Assert.ThrowsAsync<ArgumentNullException>(() => _repository.ChangeStudyCourseAsync(updatedStudyCourseDTO));
        }

        [Test]
        public async Task ChangeStudyCourseAsync_InvalidStudyCourseId_ThrowsArgumentNullException()
        {
            var updatedStudyCourseDTO = new StudyCourseDTO
            {
                Id = 2,
                School = "UpdatedSchool",
                Study = "UpdatedStudy",
                DiplomaType = "Master",
                Location = "Hasselt",
                JobRelation = 2
            };

            Assert.ThrowsAsync<ArgumentNullException>(() => _repository.ChangeStudyCourseAsync(updatedStudyCourseDTO));
        }

        [Test]
        public async Task DeleteStudyCourseAsync_ValidId_ReturnsTrue()
        {
            var studyCourse = new StudyCourse
            {
                Id = 1,
                School = "School",
                Study = "Study",
                DiplomaType = Diploma.Bachelor,
                Location = Location.Leuven,
                JobRelation = 1
            };

            _dbContext.StudyCourses.Add(studyCourse);
            await _dbContext.SaveChangesAsync();


            var result = await _repository.DeleteStudyCourseAsync(1);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteStudyCourseAsync_InvalidId_ReturnsFalse()
        {
            var result = await _repository.DeleteStudyCourseAsync(1);

            Assert.IsFalse(result);
        }

        [Test]
        public void GetAllDiplomasAsync_ReturnsAllDiplomas()
        {
            var result = _repository.GetAllDiplomasAsync().Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count); 
        }

        [Test]
        public void GetAllLocationsAsync_ReturnsAllLocations()
        {
            var result = _repository.GetAllLocationsAsync().Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(28, result.Count);
        }

        [Test]
        public async Task GetStudyCoursesByRelationAsync_ValidRelationId_ReturnsStudyCourses()
        {
            var studyCourses = new List<StudyCourse>
            {
                new StudyCourse { Id = 1, School = "School1", Study = "Study1", DiplomaType = Diploma.Bachelor, Location = Location.Hasselt, JobRelation = 1 },
                new StudyCourse { Id = 2, School = "School2", Study = "Study2", DiplomaType = Diploma.Master, Location = Location.Hasselt, JobRelation = 1 },
            };

            _dbContext.StudyCourses.AddRange(studyCourses);
            await _dbContext.SaveChangesAsync();

            var result = await _repository.GetStudyCoursesByRelationAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task GetStudyCoursesByRelationAsync_InvalidRelationId_ReturnsEmptyList()
        {
            var result = await _repository.GetStudyCoursesByRelationAsync(1);

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetStudyCoursesAsync_ReturnsAllStudyCourses()
        {
            var studyCourses = new List<StudyCourse>
            {
                new StudyCourse { Id = 1, School = "School1", Study = "Study1", DiplomaType = Diploma.Bachelor, Location = Location.Hasselt, JobRelation = 1 },
                new StudyCourse { Id = 2, School = "School2", Study = "Study2", DiplomaType = Diploma.Master, Location = Location.Hasselt, JobRelation = 2 },
            };

            _dbContext.StudyCourses.AddRange(studyCourses);
            await _dbContext.SaveChangesAsync();

            var result = await _repository.GetStudyCoursesAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}

