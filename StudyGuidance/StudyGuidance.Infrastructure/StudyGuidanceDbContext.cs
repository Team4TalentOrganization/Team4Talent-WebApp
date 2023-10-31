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
                Phrase = "In welk domein interesseer je je?",
                QuestionId = 1
            };

            modelBuilder.Entity<Question>().HasData(domainQuestion);

            modelBuilder.Entity<Option>().HasData(
                        new Option { OptionId = 1, Content = "AI", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 2, Content = "Development", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 3, Content = "Software Engineering", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 4, Content = "Systeem en netwerkbeheer", QuestionId = domainQuestion.QuestionId },
                        new Option { OptionId = 5, Content = "Data", QuestionId = domainQuestion.QuestionId }
            );
        }
    }
}
