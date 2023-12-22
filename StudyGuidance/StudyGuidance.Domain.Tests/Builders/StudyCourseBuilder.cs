using System;

namespace StudyGuidance.Domain.Tests.Builders
{
    public class StudyCourseBuilder : BuilderBase<StudyCourse>
    {
        public StudyCourseBuilder WithId(int id)
        {
            SetProperty(s => s.Id, id);
            return this;
        }

        public StudyCourseBuilder WithSchool(string school)
        {
            SetProperty(s => s.School, school);
            return this;
        }

        public StudyCourseBuilder WithStudy(string study)
        {
            SetProperty(s => s.Study, study);
            return this;
        }

        public StudyCourseBuilder WithDiplomaType(Diploma diplomaType)
        {
            SetProperty(s => s.DiplomaType, diplomaType);
            return this;
        }

        public StudyCourseBuilder WithLocation(Location location)
        {
            SetProperty(s => s.Location, location);
            return this;
        }

        public StudyCourseBuilder WithJobRelation(int jobRelation)
        {
            SetProperty(s => s.JobRelation, jobRelation);
            return this;
        }

        public StudyCourseBuilder WithRandomValues()
        {
            var randomId = Random.Next(1, 100);
            var randomSchool = "School" + Random.Next(1, 10);
            var randomStudy = "Study" + Random.Next(1, 10);
            var randomDiplomaType = (Diploma)Random.Next(0, Enum.GetNames(typeof(Diploma)).Length);
            var randomLocation = (Location)Random.Next(0, Enum.GetNames(typeof(Location)).Length);
            var randomJobRelation = Random.Next(1, 100);

            return WithId(randomId)
                .WithSchool(randomSchool)
                .WithStudy(randomStudy)
                .WithDiplomaType(randomDiplomaType)
                .WithLocation(randomLocation)
                .WithJobRelation(randomJobRelation);
        }

        public override StudyCourse Build()
        {
            return base.Build();
        }
    }
}

