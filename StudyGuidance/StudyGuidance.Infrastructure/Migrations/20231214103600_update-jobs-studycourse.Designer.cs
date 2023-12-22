﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyGuidance.Infrastructure;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    [DbContext(typeof(StudyGuidanceDbContext))]
    [Migration("20231214103600_update-jobs-studycourse")]
    partial class updatejobsstudycourse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StudyGuidance.Domain.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptionRelation")
                        .HasColumnType("int");

                    b.Property<int>("StudyCourseRelation")
                        .HasColumnType("int");

                    b.Property<string>("SubDomain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WorkInTeam")
                        .HasColumnType("bit");

                    b.Property<bool>("WorkOnSite")
                        .HasColumnType("bit");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            JobId = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Software Management",
                            Name = "Tester",
                            OptionRelation = 15,
                            StudyCourseRelation = 1,
                            SubDomain = "Software analysis",
                            WorkInTeam = false,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 2,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Software Management",
                            Name = "QA Engineer",
                            OptionRelation = 14,
                            StudyCourseRelation = 1,
                            SubDomain = "Project Management",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 3,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Software Management",
                            Name = "Business Analyst",
                            OptionRelation = 15,
                            StudyCourseRelation = 1,
                            SubDomain = "Software analysis",
                            WorkInTeam = true,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 4,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Software Management",
                            Name = "Functional Analyst",
                            OptionRelation = 15,
                            StudyCourseRelation = 1,
                            SubDomain = "Software analysis",
                            WorkInTeam = true,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 5,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "Application Support",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 6,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Software Management",
                            Name = "Helpdesk",
                            OptionRelation = 14,
                            StudyCourseRelation = 1,
                            SubDomain = "Project Management",
                            WorkInTeam = false,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 7,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "PHP Developer",
                            OptionRelation = 13,
                            StudyCourseRelation = 1,
                            SubDomain = "Backend",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 8,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "Drupal Developer",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 9,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "Cobol Developer",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 10,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "Dynammics Developer",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 11,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "Java Developer",
                            OptionRelation = 13,
                            StudyCourseRelation = 1,
                            SubDomain = "Backend",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 12,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "SAP Developer",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 13,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "Siebel Developer",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 14,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "RPG developer",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 15,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Systeem en netwerkbeheer",
                            Name = "System admin",
                            OptionRelation = 18,
                            StudyCourseRelation = 1,
                            SubDomain = "Networking",
                            WorkInTeam = false,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 16,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Systeem en netwerkbeheer",
                            Name = "Network engineer",
                            OptionRelation = 18,
                            StudyCourseRelation = 1,
                            SubDomain = "Networking",
                            WorkInTeam = false,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 17,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Data",
                            Name = "Data migration expert",
                            OptionRelation = 22,
                            StudyCourseRelation = 1,
                            SubDomain = "Analyst",
                            WorkInTeam = false,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 18,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Data",
                            Name = "Data architect",
                            OptionRelation = 22,
                            StudyCourseRelation = 1,
                            SubDomain = "Analyst",
                            WorkInTeam = false,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 19,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Data",
                            Name = "Database administrator",
                            OptionRelation = 22,
                            StudyCourseRelation = 1,
                            SubDomain = "Analyst",
                            WorkInTeam = false,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 20,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Systeem en netwerkbeheer",
                            Name = "AWS DevOps Engineer",
                            OptionRelation = 16,
                            StudyCourseRelation = 1,
                            SubDomain = "Automation",
                            WorkInTeam = false,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 21,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Software Management",
                            Name = "Project manager",
                            OptionRelation = 14,
                            StudyCourseRelation = 1,
                            SubDomain = "Project Management",
                            WorkInTeam = true,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 22,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Systeem en netwerkbeheer",
                            Name = "Azure DevOps Engineer",
                            OptionRelation = 16,
                            StudyCourseRelation = 1,
                            SubDomain = "Automation",
                            WorkInTeam = false,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 23,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "SharePoint Developer",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 24,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = ".NET Developer",
                            OptionRelation = 13,
                            StudyCourseRelation = 1,
                            SubDomain = "Backend",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 25,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "Frontend Developer",
                            OptionRelation = 12,
                            StudyCourseRelation = 1,
                            SubDomain = "Frontend",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 26,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "Software Architect",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = false,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 27,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Development",
                            Name = "Development Team Lead",
                            OptionRelation = 11,
                            StudyCourseRelation = 1,
                            SubDomain = "Fullstack",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 28,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Software Management",
                            Name = "SCRUM Master",
                            OptionRelation = 14,
                            StudyCourseRelation = 1,
                            SubDomain = "Project Management",
                            WorkInTeam = true,
                            WorkOnSite = true
                        },
                        new
                        {
                            JobId = 29,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Systeem en netwerkbeheer",
                            Name = "Security Engineer",
                            OptionRelation = 17,
                            StudyCourseRelation = 1,
                            SubDomain = "Security",
                            WorkInTeam = false,
                            WorkOnSite = false
                        },
                        new
                        {
                            JobId = 30,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                            Domain = "Systeem en netwerkbeheer",
                            Name = "PEN Tester",
                            OptionRelation = 17,
                            StudyCourseRelation = 1,
                            SubDomain = "Security",
                            WorkInTeam = false,
                            WorkOnSite = true
                        });
                });

            modelBuilder.Entity("StudyGuidance.Domain.Option", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OptionId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<int>("OptionRelation")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("OptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            OptionId = 1,
                            Content = "AI",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 2,
                            Content = "Development",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 3,
                            Content = "Software Management",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 4,
                            Content = "Systeem en netwerkbeheer",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 5,
                            Content = "Elektronica",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 6,
                            Content = "Data",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 7,
                            Content = "VR & AR",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 8,
                            Content = "AI Robotics",
                            IsChecked = false,
                            OptionRelation = 1,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 9,
                            Content = "Machine Learning",
                            IsChecked = false,
                            OptionRelation = 1,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 10,
                            Content = "Computer Vision",
                            IsChecked = false,
                            OptionRelation = 1,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 11,
                            Content = "Fullstack",
                            IsChecked = false,
                            OptionRelation = 2,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 12,
                            Content = "Frontend",
                            IsChecked = false,
                            OptionRelation = 2,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 13,
                            Content = "Backend",
                            IsChecked = false,
                            OptionRelation = 2,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 14,
                            Content = "Project Management",
                            IsChecked = false,
                            OptionRelation = 3,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 15,
                            Content = "Software analysis",
                            IsChecked = false,
                            OptionRelation = 3,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 16,
                            Content = "Automation",
                            IsChecked = false,
                            OptionRelation = 4,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 17,
                            Content = "Security",
                            IsChecked = false,
                            OptionRelation = 4,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 18,
                            Content = "Networking",
                            IsChecked = false,
                            OptionRelation = 4,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 19,
                            Content = "Elektronica-ICT",
                            IsChecked = false,
                            OptionRelation = 5,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 20,
                            Content = "Internet of Things",
                            IsChecked = false,
                            OptionRelation = 5,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 21,
                            Content = "Elektromechanica",
                            IsChecked = false,
                            OptionRelation = 5,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 22,
                            Content = "Analyst",
                            IsChecked = false,
                            OptionRelation = 6,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 23,
                            Content = "Data AI",
                            IsChecked = false,
                            OptionRelation = 6,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 24,
                            Content = "VR",
                            IsChecked = false,
                            OptionRelation = 7,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 25,
                            Content = "AR",
                            IsChecked = false,
                            OptionRelation = 7,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 26,
                            Content = "Ja",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 3
                        },
                        new
                        {
                            OptionId = 27,
                            Content = "Nee",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 3
                        },
                        new
                        {
                            OptionId = 28,
                            Content = "Ja",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 4
                        },
                        new
                        {
                            OptionId = 29,
                            Content = "Nee",
                            IsChecked = false,
                            OptionRelation = 0,
                            QuestionId = 4
                        });
                });

            modelBuilder.Entity("StudyGuidance.Domain.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<string>("Phrase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionType")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Phrase = "In welk domein heb je interesse?",
                            QuestionType = 1
                        },
                        new
                        {
                            QuestionId = 2,
                            Phrase = "In welk subdomein heb je interesse?",
                            QuestionType = 1
                        },
                        new
                        {
                            QuestionId = 3,
                            Phrase = "Werk je graag vaak in groep?",
                            QuestionType = 0
                        },
                        new
                        {
                            QuestionId = 4,
                            Phrase = "Reis je graag voor je werk?",
                            QuestionType = 0
                        });
                });

            modelBuilder.Entity("StudyGuidance.Domain.StudyCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DiplomaType")
                        .HasColumnType("int");

                    b.Property<int>("JobRelation")
                        .HasColumnType("int");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Study")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StudyCourses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiplomaType = 0,
                            JobRelation = 0,
                            Location = 0,
                            School = "Syntra",
                            Study = "Switch2It"
                        },
                        new
                        {
                            Id = 2,
                            DiplomaType = 0,
                            JobRelation = 0,
                            Location = 0,
                            School = "Hogeschool PXL",
                            Study = "Toegpaste Informatica"
                        },
                        new
                        {
                            Id = 3,
                            DiplomaType = 1,
                            JobRelation = 0,
                            Location = 0,
                            School = "Hogeschool PXL",
                            Study = "Elektronica-ICT"
                        },
                        new
                        {
                            Id = 4,
                            DiplomaType = 2,
                            JobRelation = 0,
                            Location = 1,
                            School = "Leuven",
                            Study = "Master: Toegepaste Informatica"
                        });
                });

            modelBuilder.Entity("StudyGuidance.Domain.Option", b =>
                {
                    b.HasOne("StudyGuidance.Domain.Question", null)
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyGuidance.Domain.Question", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
