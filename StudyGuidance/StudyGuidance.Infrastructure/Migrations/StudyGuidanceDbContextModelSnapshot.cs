﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyGuidance.Infrastructure;

#nullable disable

namespace StudyGuidance.Infrastructure.Migrations
{
    [DbContext(typeof(StudyGuidanceDbContext))]
    partial class StudyGuidanceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 2,
                            Content = "Development",
                            IsChecked = false,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 3,
                            Content = "Software Management",
                            IsChecked = false,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 4,
                            Content = "Systeem en netwerkbeheer",
                            IsChecked = false,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 5,
                            Content = "Elektronica",
                            IsChecked = false,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 6,
                            Content = "Data",
                            IsChecked = false,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 7,
                            Content = "VR & AR",
                            IsChecked = false,
                            QuestionId = 1
                        },
                        new
                        {
                            OptionId = 8,
                            Content = "Backend",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 9,
                            Content = "AI Robotics",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 10,
                            Content = "Machine Learning",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 11,
                            Content = "Computer Vision",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 12,
                            Content = "Project Management",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 13,
                            Content = "Software analysis",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 14,
                            Content = "Automation",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 15,
                            Content = "Security",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 16,
                            Content = "Networking",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 17,
                            Content = "Elektronica-ICT",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 18,
                            Content = "Internet of Things",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 19,
                            Content = "Elektromechanica",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 20,
                            Content = "Analyst",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 21,
                            Content = "Data AI",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 22,
                            Content = "VR",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 23,
                            Content = "AR",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 24,
                            Content = "Fullstack",
                            IsChecked = false,
                            QuestionId = 2
                        },
                        new
                        {
                            OptionId = 25,
                            Content = "Frontend",
                            IsChecked = false,
                            QuestionId = 2
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

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Phrase = "In welk domein heb je interesse?"
                        },
                        new
                        {
                            QuestionId = 2,
                            Phrase = "In welk subdomein heb je interesse?"
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
