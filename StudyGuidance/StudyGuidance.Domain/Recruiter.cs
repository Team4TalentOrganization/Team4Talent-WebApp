using StudyGuidance.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudyGuidance.Domain
{
    public class Recruiter
    {
        public int? RecruiterId { get; set; }
        public string _firstName { get; set; } = string.Empty;
        public string _lastName { get; set; } = string.Empty;
        public string _email { get; set; } = string.Empty;
        public string _company { get; set; } = string.Empty;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("FirstName cannot be null or empty.");
                }

                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("LastName cannot be null or empty.");
                }

                _lastName = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("Email cannot be null or empty.");
                }

                _email = value;
            }
        }

        public string Company
        {
            get => _company;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BusinessException("Company cannot be null or empty.");
                }

                _company = value;
            }
        }
    }
}
