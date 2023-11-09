using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using StudyGuidance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Infrastructure
{
    internal class StudyGuidanceDbContext: DbContext
    {
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Option> Options { get; set; } = null!;

        public StudyGuidanceDbContext(DbContextOptions<StudyGuidanceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var domainQuestion = new Question
            {
                Phrase = "In welk domein heb je interesse?",
                QuestionId = 1
            };

            var subDomainQuestion = new Question
            {
                Phrase = "In welk subdomein heb je interesse?",
                QuestionId = 2
            };

            modelBuilder.Entity<Question>().HasData(domainQuestion);
            modelBuilder.Entity<Question>().HasData(subDomainQuestion);

            modelBuilder.Entity<Option>().HasData(
                        new Option { OptionId = 1, Content = "AI", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 2, Content = "Development", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 3, Content = "Software Management", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 4, Content = "Systeem en netwerkbeheer", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 5, Content = "Elektronica", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 6, Content = "Data", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 7, Content = "VR & AR", QuestionId = domainQuestion.QuestionId }
            );

            modelBuilder.Entity<Option>().HasData(
            new Option { OptionId = 8, Content = "Backend", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 9, Content = "AI Robotics", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 10, Content = "Machine Learning", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 11, Content = "Computer Vision", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 12, Content = "Project Management", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 13, Content = "Software analysis", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 14, Content = "Automation", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 15, Content = "Security", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 16, Content = "Networking", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 17, Content = "Elektronica-ICT", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 18, Content = "Internet of Things", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 19, Content = "Elektromechanica", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 20, Content = "Analyst", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 21, Content = "Data AI", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 22, Content = "VR", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 23, Content = "AR", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 24, Content = "Fullstack", QuestionId = subDomainQuestion.QuestionId },
            new Option { OptionId = 25, Content = "Frontend", QuestionId = subDomainQuestion.QuestionId }
            );
        }
    }
}
