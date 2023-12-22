using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Models
{
    public class JobRequest
    {
        public string? Name { get; set; }
        public string? Domain { get; set; }
        public string? SubDomain { get; set; }
        public string? Description { get; set; }
        public bool WorkInTeam { get; set; }
        public bool WorkOnSite { get; set; }
        public TestimonialRequest TestamonialRequest { get; set; }
    }
}
