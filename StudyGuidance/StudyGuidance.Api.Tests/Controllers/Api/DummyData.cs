using StudyGuidance.Domain.Models;
using StudyGuidance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Api.Tests.Controllers.Api
{
    public static class DummyData
    {
        public static Job CreateDummyJob()
        {
            var jobRequest = new JobRequest
            {
                Name = "Software Engineer",
                Domain = "IT",
                SubDomain = "Development",
                Description = "Develop software applications",
                WorkInTeam = true,
                WorkOnSite = false,
                TestamonialRequest = new TestimonialRequest
                {
                    Name = "John Doe",
                    Description = "A satisfied employee",
                    JobTitel = "Senior Software Engineer"
                }
            };

            return new Job(jobRequest);
        }

        public static Testamonial CreateDummyTestamonial()
        {
            var testimonialRequest = new TestimonialRequest
            {
                Name = "Jane Doe",
                Description = "Great experience working here",
                JobTitel = "Software Developer"
            };

            return new Testamonial(testimonialRequest, jobId: 1);
        }

        public static StudyCourse CreateDummyStudyCourse()
        {
            var studyCourseRequest = new StudyCourseRequest
            {
                Study = "Computer Science",
                School = "University of XYZ",
                DiplomaType = "Bachelor", 
                Location = "Hasselt",
                JobRelation = 1
            };

            return new StudyCourse(studyCourseRequest);
        }
    }
}
