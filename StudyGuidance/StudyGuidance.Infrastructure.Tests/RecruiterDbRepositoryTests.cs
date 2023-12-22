using Microsoft.EntityFrameworkCore;
using StudyGuidance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Infrastructure.Tests
{
    public class RecruiterDbRepositoryTests
    {
        private RecruiterDbRepository _repository;
        private StudyGuidanceDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<StudyGuidanceDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryStudyGuidanceDb")
                .Options;

            _dbContext = new StudyGuidanceDbContext(options);
            _repository = new RecruiterDbRepository(_dbContext);
        }

        [Test]
        public async Task GetRecruitersAsync_ReturnsAllRecruitersFromRepository()
        {
            // Arrange
            var recruiters = new List<Recruiter>
            {
                new Recruiter { RecruiterId = 1, FirstName = "Mieszko", LastName = "B", Email = "mieszko.b@gmail.com", Company = "Fenego" },
                new Recruiter { RecruiterId = 2, FirstName = "Ruben", LastName = "O", Email = "ruben.o@gmail.com", Company = "Cegeka" },
                new Recruiter { RecruiterId = 3, FirstName = "Dries", LastName = "C", Email = "driesb@gmail.com", Company = "ACA" }
            };
            _dbContext.Recruiters.AddRange(recruiters);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetRecruitersAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(3, Is.EqualTo(result.Count));
        }

        [Test]
        public async Task GetRecruiterByIdAsync_ReturnsRequestedRecruiterFromRepository()
        {
            // Arrange
            var recruiters = new List<Recruiter>
            {
                new Recruiter { RecruiterId = 1, FirstName = "Mieszko", LastName = "B", Email = "mieszko.b@gmail.com", Company = "Fenego" },
                new Recruiter { RecruiterId = 2, FirstName = "Ruben", LastName = "O", Email = "ruben.o@gmail.com", Company = "Cegeka" },
                new Recruiter { RecruiterId = 3, FirstName = "Dries", LastName = "C", Email = "driesb@gmail.com", Company = "ACA" }
            };

            _dbContext.Recruiters.AddRange(recruiters);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetRecruiterByIdAsync(3);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.RecruiterId, Is.EqualTo(3));
        }

        [Test]
        public async Task AddRecruiter_ShouldAddRecruiterToRepository()
        {
            // Arrange
            var recruiters = new List<Recruiter>
            {
                new Recruiter { RecruiterId = 1, FirstName = "Mieszko", LastName = "B", Email = "mieszko.b@gmail.com", Company = "Fenego" },
                new Recruiter { RecruiterId = 2, FirstName = "Ruben", LastName = "O", Email = "ruben.o@gmail.com", Company = "Cegeka" },
                new Recruiter { RecruiterId = 3, FirstName = "Dries", LastName = "C", Email = "driesb@gmail.com", Company = "ACA" }
            };

            var recruiterToAdd = new Recruiter { RecruiterId = 4, FirstName = "Noah", LastName = "R", Email = "noah.r@gmail.com", Company = "Alpine Digital" };

            _dbContext.Recruiters.AddRange(recruiters);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.AddRecruiter(recruiterToAdd);
            var recruitersInRepository = _dbContext.Recruiters.ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.RecruiterId, Is.EqualTo(4));
            Assert.That(recruitersInRepository.Count, Is.EqualTo(4));
        }

        [Test]
        public async Task DeleteRecruiter_ShouldDeleteRecruiterFromRepository()
        {
            // Arrange
            var recruiters = new List<Recruiter>
            {
                new Recruiter { RecruiterId = 1, FirstName = "Mieszko", LastName = "B", Email = "mieszko.b@gmail.com", Company = "Fenego" },
                new Recruiter { RecruiterId = 2, FirstName = "Ruben", LastName = "O", Email = "ruben.o@gmail.com", Company = "Cegeka" },
                new Recruiter { RecruiterId = 3, FirstName = "Dries", LastName = "C", Email = "driesb@gmail.com", Company = "ACA" }
            };

            _dbContext.Recruiters.AddRange(recruiters);
            _dbContext.SaveChanges();

            // Act
            await _repository.DeleteRecruiter(3);
            var recruitersInRepository = _dbContext.Recruiters.ToList();

            // Assert
            Assert.That(recruitersInRepository.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task UpdateRecruiter_ShouldUpdateRecruiterInRepository()
        {
            // Arrange
            var recruiters = new List<Recruiter>
            {
                new Recruiter { RecruiterId = 1, FirstName = "Mieszko", LastName = "B", Email = "mieszko.b@gmail.com", Company = "Fenego" },
                new Recruiter { RecruiterId = 2, FirstName = "Ruben", LastName = "O", Email = "ruben.o@gmail.com", Company = "Cegeka" },
                new Recruiter { RecruiterId = 3, FirstName = "Dries", LastName = "C", Email = "driesb@gmail.com", Company = "ACA" }
            };

            var recruiterToUpdate = new Recruiter { RecruiterId = 1, FirstName = "Noah", LastName = "R", Email = "noah.r@gmail.com", Company = "Alpine Digital" };

            _dbContext.Recruiters.AddRange(recruiters);
            _dbContext.SaveChanges();

            // Act
            await _repository.UpdateRecruiterAsync(recruiterToUpdate);
            var recruitersInRepository = _dbContext.Recruiters.ToList();
            var updatedRecruiter = _dbContext.Recruiters.Find(1); // Find the updated recruiter by ID

            // Assert
            Assert.IsNotNull(updatedRecruiter);
            Assert.That(updatedRecruiter.FirstName, Is.EqualTo("Noah"));
            Assert.That(updatedRecruiter.LastName, Is.EqualTo("R"));
            Assert.That(updatedRecruiter.Email, Is.EqualTo("noah.r@gmail.com"));
            Assert.That(updatedRecruiter.Company, Is.EqualTo("Alpine Digital"));
            Assert.That(recruitersInRepository.Count, Is.EqualTo(3));
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted(); // database deleten
            _dbContext.Dispose();
        }
    }
}
