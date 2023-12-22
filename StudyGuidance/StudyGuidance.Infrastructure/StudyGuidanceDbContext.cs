using Microsoft.EntityFrameworkCore;
using StudyGuidance.Domain;

namespace StudyGuidance.Infrastructure
{
    internal class StudyGuidanceDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Option> Options { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Recruiter> Recruiters { get; set; } = null!;
        public DbSet<StudyCourse> StudyCourses { get; set; } = null!;
        public DbSet<Testamonial> Testamonials { get; set; } = null!;

        public StudyGuidanceDbContext(DbContextOptions<StudyGuidanceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Testamonial)
                .WithOne()
    .           HasForeignKey<Testamonial>(t => t.JobId);

            var domainQuestion = new Question
            {
                Phrase = "In welk domein heb je interesse?",
                QuestionId = 1,
                QuestionType = QuestionType.StandardQuizQuestion
            };

            var subDomainQuestion = new Question
            {
                Phrase = "In welk subdomein heb je interesse?",
                QuestionId = 2,
                QuestionType = QuestionType.StandardQuizQuestion
            };

            var workInTeamQuestion = new Question
            {
                Phrase = "Werk je graag vaak in groep?",
                QuestionId = 3,
                QuestionType = QuestionType.TinderQuizQuestion
            };

            var workOnSiteQuestion = new Question
            {
                Phrase = "Reis je graag voor je werk?",
                QuestionId = 4,
                QuestionType = QuestionType.TinderQuizQuestion
            };

            modelBuilder.Entity<Testamonial>().HasData(
                new Testamonial { Id = 1, JobId = 1, Name = "Luca Hendrickx", JobTitel = "QA Enigneer consultant",Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 2, JobId = 2, Name = "QA Engineer 1", JobTitel = "QA Engineer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. As a QA Engineer, I've had the opportunity to work on challenging projects and collaborate with a talented team." },
                new Testamonial { Id = 3, JobId = 3, Name = "Business Analyst 1", JobTitel = "Business Analyst", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Working as a Business Analyst, I've been involved in critical analysis and decision-making, contributing to the success of the organization." },
                new Testamonial { Id = 4, JobId = 4, Name = "QA Engineer 2", JobTitel = "QA Engineer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. As a QA Engineer, I've had the opportunity to work on innovative projects and contribute to the continuous improvement of software quality." },
                new Testamonial { Id = 5, JobId = 5, Name = "Business Analyst 2", JobTitel = "Business Analyst", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Being a Business Analyst, I've played a key role in aligning business goals with technological solutions, ensuring successful project outcomes." },
                new Testamonial { Id = 6, JobId = 6, Name = "Helpdesk 1", JobTitel = "Helpdesk", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 7, JobId = 7, Name = "PHP Developer 1", JobTitel = "PHP Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 8, JobId = 8, Name = "Drupal Developer 1", JobTitel = "Drupal Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 9, JobId = 9, Name = "Cobol Developer 1", JobTitel = "Cobol Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 10, JobId = 10, Name = "Dynammics Developer 1", JobTitel = "Dynammics Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 11, JobId = 11, Name = "Java Developer 1", JobTitel = "Java Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 12, JobId = 12, Name = "SAP Developer 1", JobTitel = "SAP Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 13, JobId = 13, Name = "Siebel Developer 1", JobTitel = "Siebel Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 14, JobId = 14, Name = "RPG developer 1", JobTitel = "RPG developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 15, JobId = 15, Name = "System admin 1", JobTitel = "System admin", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 16, JobId = 16, Name = "Network engineer 1", JobTitel = "Network engineer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 17, JobId = 17, Name = "Data migration expert 1", JobTitel = "Data migration expert", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 18, JobId = 18, Name = "Data architect 1", JobTitel = "Data architect", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 19, JobId = 19, Name = "Database administrator 1", JobTitel = "Database administrator", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 20, JobId = 20, Name = "AWS DevOps Engineer 1", JobTitel = "AWS DevOps Engineer" , Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 21, JobId = 21, Name = "Project manager 1", JobTitel = "Project manager", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 22, JobId = 22, Name = "Azure DevOps Engineer 1", JobTitel = "Azure DevOps Engineer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 23, JobId = 23, Name = "SharePoint Developer 1", JobTitel = "SharePoint Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 24, JobId = 24, Name = ".NET Developer 1", JobTitel = ".NET Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 25, JobId = 25, Name = "Frontend Developer 1", JobTitel = "Frontend Developer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 26, JobId = 26, Name = "Software Architect 1", JobTitel = "Software Architect", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 27, JobId = 27, Name = "Development Team Lead 1", JobTitel = "Development Team Lead", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 28, JobId = 28, Name = "SCRUM Master 1", JobTitel = "SCRUM Master", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 29, JobId = 29, Name = "Security Engineer 1", JobTitel = "Security Engineer", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
                new Testamonial { Id = 30, JobId = 30, Name = "PEN Tester 1", JobTitel = "PEN Tester", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." }
                );

            modelBuilder.Entity<StudyCourse>().HasData(
                new StudyCourse { Id = 1, DiplomaType = Diploma.Graduaat, Location = Location.Hasselt, Study = "Switch2It", School = "Syntra", JobRelation = 1 },
                new StudyCourse { Id = 2, DiplomaType = Diploma.Graduaat, Location = Location.Hasselt, Study = "Toegpaste Informatica", School = "Hogeschool PXL", JobRelation = 1 },
                new StudyCourse { Id = 3, DiplomaType = Diploma.Bachelor, Location = Location.Hasselt, Study = "Elektronica-ICT", School = "Hogeschool PXL", JobRelation = 1 },
                new StudyCourse { Id = 4, DiplomaType = Diploma.Master, Location = Location.Leuven, Study = "Master: Toegepaste Informatica", School = "KU Leuven", JobRelation = 1 },
                new StudyCourse { Id = 5, DiplomaType = Diploma.Bachelor, Location = Location.Leuven, Study = "Biomedische Wetenschappen", School = "KU Leuven", JobRelation = 2 },
                new StudyCourse { Id = 6, DiplomaType = Diploma.Master, Location = Location.Brussels, Study = "Master in Business Administration", School = "VUB", JobRelation = 3 },
                new StudyCourse { Id = 7, DiplomaType = Diploma.Graduaat, Location = Location.Antwerp, Study = "Marketing Management", School = "Artesis Plantijn Hogeschool", JobRelation = 3 },
                new StudyCourse { Id = 8, DiplomaType = Diploma.Bachelor, Location = Location.Ghent, Study = "Communication Sciences", School = "UGent", JobRelation = 4 },
                new StudyCourse { Id = 9, DiplomaType = Diploma.Master, Location = Location.Bruges, Study = "Master in Environmental Sciences", School = "Howest", JobRelation = 4 },
                new StudyCourse { Id = 10, DiplomaType = Diploma.Bachelor, Location = Location.Liege, Study = "Computer Science", School = "Université de Liège", JobRelation = 4 },
                new StudyCourse { Id = 11, DiplomaType = Diploma.Master, Location = Location.Namur, Study = "Master in Physics", School = "Université de Namur", JobRelation = 5 },
                new StudyCourse { Id = 12, DiplomaType = Diploma.Graduaat, Location = Location.LouvainLaNeuve, Study = "Multimedia Production", School = "Haute École Louvain en Hainaut", JobRelation = 5 },
                new StudyCourse { Id = 13, DiplomaType = Diploma.Bachelor, Location = Location.Mons, Study = "Industrial Engineering", School = "Université de Mons", JobRelation = 6 },
                new StudyCourse { Id = 14, DiplomaType = Diploma.Master, Location = Location.Aalst, Study = "Master in Artificial Intelligence", School = "Hogeschool Odisee", JobRelation = 7 },
                new StudyCourse { Id = 15, DiplomaType = Diploma.Graduaat, Location = Location.Genk, Study = "Digital Marketing", School = "C-Mine Crib", JobRelation = 8 },
                new StudyCourse { Id = 16, DiplomaType = Diploma.Bachelor, Location = Location.Kortrijk, Study = "Product Design", School = "Howest", JobRelation = 9 },
                new StudyCourse { Id = 17, DiplomaType = Diploma.Master, Location = Location.Ostend, Study = "Master in Marine Biology", School = "VIVES University College", JobRelation = 9 },
                new StudyCourse { Id = 18, DiplomaType = Diploma.Graduaat, Location = Location.SintNiklaas, Study = "Web Development", School = "HoGent", JobRelation = 9 },
                new StudyCourse { Id = 19, DiplomaType = Diploma.Bachelor, Location = Location.Mechelen, Study = "International Business", School = "Thomas More", JobRelation = 9 },
                new StudyCourse { Id = 20, DiplomaType = Diploma.Master, Location = Location.Tournai, Study = "Master in Environmental Engineering", School = "Haute École de la Province de Hainaut Condorcet", JobRelation = 9 },
                new StudyCourse { Id = 21, DiplomaType = Diploma.Bachelor, Location = Location.Dendermonde, Study = "Applied Mathematics", School = "Hogeschool Gent", JobRelation = 10 },
                new StudyCourse { Id = 22, DiplomaType = Diploma.Master, Location = Location.Roeselare, Study = "Master in Industrial Design", School = "Howest", JobRelation = 10 },
                new StudyCourse { Id = 23, DiplomaType = Diploma.Bachelor, Location = Location.Verviers, Study = "Electrical Engineering", School = "Haute École de la Province de Liège", JobRelation = 11 },
                new StudyCourse { Id = 24, DiplomaType = Diploma.Graduaat, Location = Location.Turnhout, Study = "Graphic Design", School = "Thomas More", JobRelation = 12 },
                new StudyCourse { Id = 25, DiplomaType = Diploma.Bachelor, Location = Location.SaintGhislain, Study = "Industrial Automation", School = "HEPH-Condorcet", JobRelation = 12 },
                new StudyCourse { Id = 26, DiplomaType = Diploma.Master, Location = Location.Waterloo, Study = "Master in Civil Engineering", School = "Université catholique de Louvain", JobRelation = 12 },
                new StudyCourse { Id = 27, DiplomaType = Diploma.Bachelor, Location = Location.Ieper, Study = "Tourism and Leisure Management", School = "Hogeschool VIVES", JobRelation = 13 },
                new StudyCourse { Id = 28, DiplomaType = Diploma.Master, Location = Location.KnokkeHeist, Study = "Master in Neuroscience", School = "Vrije Universiteit Brussel", JobRelation = 14 },
                new StudyCourse { Id = 29, DiplomaType = Diploma.Bachelor, Location = Location.Halle, Study = "Culinary Arts", School = "Erasmushogeschool Brussel", JobRelation = 14 },
                new StudyCourse { Id = 30, DiplomaType = Diploma.Master, Location = Location.Tongeren, Study = "Master in Archaeology", School = "Hogeschool PXL", JobRelation = 15 }
                );

            modelBuilder.Entity<Question>().HasData(domainQuestion);
            modelBuilder.Entity<Question>().HasData(subDomainQuestion);
            modelBuilder.Entity<Question>().HasData(workInTeamQuestion);
            modelBuilder.Entity<Question>().HasData(workOnSiteQuestion);

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

            modelBuilder.Entity<Option>().HasData(
            new Option { OptionId = 26, Content = "Ja", QuestionId = workInTeamQuestion.QuestionId },
            new Option { OptionId = 27, Content = "Nee", QuestionId = workInTeamQuestion.QuestionId }
            );

            modelBuilder.Entity<Option>().HasData(
            new Option { OptionId = 28, Content = "Ja", QuestionId = workOnSiteQuestion.QuestionId },
            new Option { OptionId = 29, Content = "Nee", QuestionId = workOnSiteQuestion.QuestionId }
            );

            modelBuilder.Entity<Job>().HasData(
            new Job { JobId = 1, StudyCourseRelation = 1, OptionRelation = 15, Name = "Tester", WorkInTeam = false, WorkOnSite = true, Domain = "Software Management", SubDomain = "Software analysis", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 2, StudyCourseRelation = 2, OptionRelation = 14, Name = "QA Engineer", WorkInTeam = true, WorkOnSite = true, Domain = "Software Management", SubDomain = "Project Management", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 3, StudyCourseRelation = 3, OptionRelation = 15, Name = "Business Analyst", WorkInTeam = true, WorkOnSite = false, Domain = "Software Management", SubDomain = "Software analysis", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 4, StudyCourseRelation = 4, OptionRelation = 15, Name = "Functional Analyst", WorkInTeam = true, WorkOnSite = false, Domain = "Software Management", SubDomain = "Software analysis", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 5, StudyCourseRelation = 5, OptionRelation = 11, Name = "Application Support", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 6, StudyCourseRelation = 6, OptionRelation = 14, Name = "Helpdesk", WorkInTeam = false, WorkOnSite = true, Domain = "Software Management", SubDomain = "Project Management", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 7, StudyCourseRelation = 6, OptionRelation = 13, Name = "PHP Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Backend", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 8, StudyCourseRelation = 7, OptionRelation = 11, Name = "Drupal Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 9, StudyCourseRelation = 8, OptionRelation = 11, Name = "Cobol Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 10, StudyCourseRelation = 9, OptionRelation = 11, Name = "Dynammics Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 11, StudyCourseRelation = 10, OptionRelation = 13, Name = "Java Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Backend", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 12, StudyCourseRelation = 11, OptionRelation = 11, Name = "SAP Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 13, StudyCourseRelation = 12, OptionRelation = 11, Name = "Siebel Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 14, StudyCourseRelation = 13, OptionRelation = 11, Name = "RPG developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 15, StudyCourseRelation = 14, OptionRelation = 18, Name = "System admin", WorkInTeam = false, WorkOnSite = true, Domain = "Systeem en netwerkbeheer", SubDomain = "Networking", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 16, StudyCourseRelation = 15, OptionRelation = 18, Name = "Network engineer", WorkInTeam = false, WorkOnSite = false, Domain = "Systeem en netwerkbeheer", SubDomain = "Networking", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 17, StudyCourseRelation = 1, OptionRelation = 22, Name = "Data migration expert", WorkInTeam = false, WorkOnSite = false, Domain = "Data", SubDomain = "Analyst", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 18, StudyCourseRelation = 2, OptionRelation = 22, Name = "Data architect", WorkInTeam = false, WorkOnSite = false, Domain = "Data", SubDomain = "Analyst", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 19, StudyCourseRelation = 3, OptionRelation = 22, Name = "Database administrator", WorkInTeam = false, WorkOnSite = false, Domain = "Data", SubDomain = "Analyst", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 20, StudyCourseRelation = 4, OptionRelation = 16, Name = "AWS DevOps Engineer", WorkInTeam = false, WorkOnSite = false, Domain = "Systeem en netwerkbeheer", SubDomain = "Automation", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 21, StudyCourseRelation = 5, OptionRelation = 14, Name = "Project manager", WorkInTeam = true, WorkOnSite = false, Domain = "Software Management", SubDomain = "Project Management", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 22, StudyCourseRelation = 6, OptionRelation = 16, Name = "Azure DevOps Engineer", WorkInTeam = false, WorkOnSite = false, Domain = "Systeem en netwerkbeheer", SubDomain = "Automation", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 23, StudyCourseRelation = 7, OptionRelation = 11, Name = "SharePoint Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 24, StudyCourseRelation = 8, OptionRelation = 13, Name = ".NET Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Backend", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 25, StudyCourseRelation = 9, OptionRelation = 12, Name = "Frontend Developer", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Frontend", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 26, StudyCourseRelation = 10, OptionRelation = 11, Name = "Software Architect", WorkInTeam = false, WorkOnSite = false, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 27, StudyCourseRelation = 11, OptionRelation = 11, Name = "Development Team Lead", WorkInTeam = true, WorkOnSite = true, Domain = "Development", SubDomain = "Fullstack", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 28, StudyCourseRelation = 12, OptionRelation = 14, Name = "SCRUM Master", WorkInTeam = true, WorkOnSite = true, Domain = "Software Management", SubDomain = "Project Management", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 29, StudyCourseRelation = 13, OptionRelation = 17, Name = "Security Engineer", WorkInTeam = false, WorkOnSite = false, Domain = "Systeem en netwerkbeheer", SubDomain = "Security", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." },
            new Job { JobId = 30, StudyCourseRelation = 14, OptionRelation = 17, Name = "PEN Tester", WorkInTeam = false, WorkOnSite = true, Domain = "Systeem en netwerkbeheer", SubDomain = "Security", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." }
            );

            modelBuilder.Entity<Recruiter>().HasData(
            new Recruiter { RecruiterId = 1, FirstName = "Noah", LastName = "De Pauw", Company = "PXL", Email="noah.depauw@gmail.com"},
            new Recruiter { RecruiterId = 2, FirstName = "Federico", LastName = "Oliva", Company = "Bewire", Email = "federico.oliva@gmail.com" },
            new Recruiter { RecruiterId = 3, FirstName = "Ruben", LastName = "Owsiamicki", Company = "Team4Talent", Email = "ruben.owsiamicki@gmail.com" },
            new Recruiter { RecruiterId = 4, FirstName = "Mieszko", LastName = "Blazniak", Company = "Fenego", Email = "mieszko.blazniak@gmail.com" },
            new Recruiter { RecruiterId = 5, FirstName = "Max", LastName = "Valkenburg", Company = "Cegeka", Email = "max.valkenburg@gmail.com" },
            new Recruiter { RecruiterId = 6, FirstName = "Dries", LastName = "Cox", Company = "ACA", Email = "noah.depauw@gmail.com" },
            new Recruiter { RecruiterId = 7, FirstName = "Luca", LastName = "Hendrickx", Company = "ACA", Email = "luca.hendrickx@gmail.com" }
            );
        }
    }
}
