﻿using Microsoft.EntityFrameworkCore;
using StudyGuidance.Domain;

namespace StudyGuidance.Infrastructure
{
    internal class StudyGuidanceDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Option> Options { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;


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
            new Option { OptionId = 8, Content = "AI Robotics", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 1 },
            new Option { OptionId = 9, Content = "Machine Learning", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 1 },
            new Option { OptionId = 10, Content = "Computer Vision", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 1 },
            new Option { OptionId = 11, Content = "Fullstack", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 2 },
            new Option { OptionId = 12, Content = "Frontend", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 2 },
            new Option { OptionId = 13, Content = "Backend", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 2 },
            new Option { OptionId = 14, Content = "Project Management", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 3 },
            new Option { OptionId = 15, Content = "Software analysis", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 3 },
            new Option { OptionId = 16, Content = "Automation", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 4 },
            new Option { OptionId = 17, Content = "Security", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 4 },
            new Option { OptionId = 18, Content = "Networking", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 4 },
            new Option { OptionId = 19, Content = "Elektronica-ICT", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 5 },
            new Option { OptionId = 20, Content = "Internet of Things", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 5 },
            new Option { OptionId = 21, Content = "Elektromechanica", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 5 },
            new Option { OptionId = 22, Content = "Analyst", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 6 },
            new Option { OptionId = 23, Content = "Data AI", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 6 },
            new Option { OptionId = 24, Content = "VR", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 7 },
            new Option { OptionId = 25, Content = "AR", QuestionId = subDomainQuestion.QuestionId, OptionRelation = 7 }
            );

            modelBuilder.Entity<Job>().HasData(
            new Job { JobId = 1, Name = "Tester", Domain = "Software Management", SubDomain = new List<string>() { "Software Management" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 2, Name = "QA Engineer", Domain = "Software Management", SubDomain = new List<string>() { "Software Management" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 3, Name = "Business Analyst", Domain = "Software Management", SubDomain = new List<string>() { "Software analysis" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 4, Name = "Functional Analyst", Domain = "Software Management", SubDomain = new List<string>() { "Software analysis" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 5, Name = "Application Support", Domain = "Development", SubDomain = new List<string>() { "Frontend", "Backend", "Fullstack" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 6, Name = "Helpdesk", Domain = "Software Management", SubDomain = new List<string>() { "Project Management" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 7, Name = "PHP Developer", Domain = "Development", SubDomain = new List<string>() { "Backend" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 8, Name = "Drupal Developer", Domain = "Development", SubDomain = new List<string>() { "Frontend", "Backend", "Fullstack" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 9, Name = "Cobol Developer", Domain = "Development", SubDomain = new List<string>() { "Frontend", "Backend", "Fullstack" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 10, Name = "Dynammics Developer", Domain = "Development", SubDomain = new List<string>() { "Frontend", "Backend", "Fullstack" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 11, Name = "Java Developer", Domain = "Development", SubDomain = new List<string>() { "Backend" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 12, Name = "SAP Developer", Domain = "Development", SubDomain = new List<string>() { "Frontend", "Backend", "Fullstack" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 13, Name = "Siebel Developer", Domain = "Development", SubDomain = new List<string>() { "Frontend", "Backend", "Fullstack" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 14, Name = "RPG developer", Domain = "Development", SubDomain = new List<string>() { "Fullstack", "Frontend", "Backend" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 15, Name = "System admin", Domain = "Systeem en netwerkbeheer", SubDomain = new List<string>() { "Security", "Networking" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 16, Name = "Network engineer", Domain = "Systeem en netwerkbeheer", SubDomain = new List<string>() { "Networking" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 17, Name = "Data migration expert", Domain = "Data", SubDomain = new List<string>() { "Analyst" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 18, Name = "Data architect", Domain = "Data", SubDomain = new List<string>() { "Analyst" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 19, Name = "Database administrator", Domain = "Data", SubDomain = new List<string>() { "Analyst" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 20, Name = "AWS DevOps Engineer", Domain = "Systeem en netwerkbeheer", SubDomain = new List<string>() { "Automation", "Networking" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 21, Name = "Project manager", Domain = "Software Management", SubDomain = new List<string>() { "Project Management" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 22, Name = "Azure DevOps Engineer", Domain = "Systeem en netwerkbeheer", SubDomain = new List<string>() { "Automation", "Networking" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 23, Name = "SharePoint Developer", Domain = "Development", SubDomain = new List<string>() { "Fullstack", "Frontend", "Backend" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 24, Name = ".NET Developer", Domain = "Development", SubDomain = new List<string>() { "Backend" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 25, Name = "Frontend Developer", Domain = "Development", SubDomain = new List<string>() { "Frontend" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 26, Name = "Software Architect", Domain = "Development", SubDomain = new List<string>() { "Fullstack", "Frontend", "Backend" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 27, Name = "Development Team Lead", Domain = "Development", SubDomain = new List<string>() { "Fullstack", "Frontend", "Backend" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 28, Name = "SCRUM Master", Domain = "Software Management", SubDomain = new List<string>() { "Project Management" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 29, Name = "Security Engineer", Domain = "Systeem en netwerkbeheer", SubDomain = new List<string>() { "Security" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 30, Name = "PEN Tester", Domain = "Systeem en netwerkbeheer", SubDomain = new List<string>() { "Security" }, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." }

                );
        }
    }
}
