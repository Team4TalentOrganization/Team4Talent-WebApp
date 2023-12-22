using StudyGuidance.Domain.Exceptions;
using StudyGuidance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain
{
    public class Testamonial
    {
        private string _name = string.Empty;
        private string _description = string.Empty;
        private string _jobTitel = string.Empty;

        public Testamonial() { }

        public Testamonial(TestimonialRequest testimonialRequest, int jobId)
        {
            JobId = jobId;
            Name = testimonialRequest.Name;
            Description = testimonialRequest.Description;
            JobTitel = testimonialRequest.JobTitel;
        }

        public int Id { get; set; }
        public int JobId { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("Name cannot be null or empty.");
                }

                _name = value;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("Description cannot be null or empty.");
                }

                _description = value;
            }
        }

        public string JobTitel
        {
            get => _jobTitel;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("JobTitel cannot be null or empty.");
                }

                _jobTitel = value;
            }
        }
    }
}
