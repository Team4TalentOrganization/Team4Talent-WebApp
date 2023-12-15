using System;

namespace StudyGuidance.Domain.Tests.Builders
{
    public class TestamonialBuilder : BuilderBase<Testamonial>
    {
        public TestamonialBuilder WithId(int id)
        {
            SetProperty(t => t.Id, id);
            return this;
        }

        public TestamonialBuilder WithJobId(int jobId)
        {
            SetProperty(t => t.JobId, jobId);
            return this;
        }

        public TestamonialBuilder WithName(string name)
        {
            SetProperty(t => t.Name, name);
            return this;
        }

        public TestamonialBuilder WithDescription(string description)
        {
            SetProperty(t => t.Description, description);
            return this;
        }

        public TestamonialBuilder WithJobTitel(string jobTitel)
        {
            SetProperty(t => t.JobTitel, jobTitel);
            return this;
        }

        public TestamonialBuilder WithRandomValues()
        {
            var randomId = Random.Next(1, 100);
            var randomJobId = Random.Next(1, 100);
            var randomName = "Name" + Random.Next(1, 10);
            var randomDescription = "Description" + Random.Next(1, 10);
            var randomJobTitel = "JobTitel" + Random.Next(1, 10);

            return WithId(randomId)
                .WithJobId(randomJobId)
                .WithName(randomName)
                .WithDescription(randomDescription)
                .WithJobTitel(randomJobTitel);
        }

        public override Testamonial Build()
        {
            return base.Build();
        }
    }
}

