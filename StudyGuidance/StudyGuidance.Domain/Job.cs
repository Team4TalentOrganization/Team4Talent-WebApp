using StudyGuidance.Domain.Exceptions;
using StudyGuidance.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain
{
    public class Job
    {
        public string _name = string.Empty;
        public string _domain = string.Empty;
        public string _subDomain = string.Empty;
        public string _description = string.Empty;
        private int _optionRelation;
        private int _studyCourseRelation;

        public Job() { }

        public Job(JobRequest jobRequest)
        {
            Name = jobRequest.Name ?? throw new BusinessException("Name cannot be null or empty.");
            Domain = jobRequest.Domain ?? throw new BusinessException("Domain cannot be null or empty.");
            SubDomain = jobRequest.SubDomain ?? throw new BusinessException("Sub domain cannot be null or empty.");
            Description = jobRequest.Description ?? throw new BusinessException("Description cannot be null or empty.");
            WorkInTeam = jobRequest.WorkInTeam;
            WorkOnSite = jobRequest.WorkOnSite;
        }

        public bool WorkInTeam { get; set; }
        public bool WorkOnSite { get; set; }
        public int JobId { get; set; }

        public int OptionRelation
        {
            get => _optionRelation;
            set
            {
                if (value <= 0)
                {
                    throw new BusinessException("OptionRelation must be greater than 0.");
                }

                _optionRelation = value;
            }
        }

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

        public string Domain
        {
            get => _domain;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("Domain cannot be null or empty.");
                }

                _domain = value;
            }
        }

        public string SubDomain
        {
            get => _subDomain;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("Sub domain list cannot be null or empty.");
                }

                _subDomain = value;
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

        public int StudyCourseRelation
        {
            get => _studyCourseRelation;
            set
            {
                if (value <= 0)
                {
                    throw new BusinessException("StudyCourseRelation must be greater than 0.");
                }

                _studyCourseRelation = value;
            }
        }

    }
}
