using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Tests.Builders
{
    public class JobBuilder : BuilderBase<Job>
    {
        public JobBuilder()
        {
            ConstructItem();
        }

        public JobBuilder WithJobId(int jobId)
        {
            SetProperty(o => o.JobId, jobId);
            return this;
        }

        public JobBuilder WithJobName(string name)
        {
            SetProperty(o => o.Name, name);
            return this;
        }

        public JobBuilder WithJobDomain(string domain)
        {
            SetProperty(o => o.Domain, domain);
            return this;
        }

        public JobBuilder WithJobSubDomain(string subDomain)
        {
            SetProperty(o => o.SubDomain, subDomain);
            return this;
        }

        public JobBuilder WithJobDescription(string description)
        {
            SetProperty(o => o.Description, description);
            return this;
        }
    }
}
