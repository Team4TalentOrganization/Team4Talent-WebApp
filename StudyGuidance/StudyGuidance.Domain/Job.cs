﻿using StudyGuidance.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain
{
    public class Job
    {
        private string _name = string.Empty;
        public string _domain = string.Empty;
        public string _subDomain = string.Empty;
        public string _description = string.Empty;

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
                    throw new BusinessException("Sub domain cannot be null or empty.");
                }

                _domain = value;
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

    }
}
