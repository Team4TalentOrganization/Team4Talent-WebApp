using NUnit.Framework;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Exceptions;
using StudyGuidance.Domain.Models;

namespace StudyGuidance.Domain.Tests
{
    [TestFixture]
    public class StudyCourseTests
    {
        [Test]
        public void Constructor_WithValidStudyCourseRequest_ShouldInitializeProperties()
        {
            var studyCourseRequest = new StudyCourseRequest
            {
                Study = "Computer Science",
                School = "University of XYZ",
                DiplomaType = "Bachelor",
                Location = "Hasselt",
                JobRelation = 123
            };

            var studyCourse = new StudyCourse(studyCourseRequest);

            Assert.AreEqual(studyCourseRequest.Study, studyCourse.Study);
            Assert.AreEqual(studyCourseRequest.School, studyCourse.School);
            Assert.AreEqual(Enum.Parse<Diploma>(studyCourseRequest.DiplomaType), studyCourse.DiplomaType);
            Assert.AreEqual(Enum.Parse<Location>(studyCourseRequest.Location), studyCourse.Location);
            Assert.AreEqual(studyCourseRequest.JobRelation, studyCourse.JobRelation);
        }

        [Test]
        public void Constructor_WithInvalidDiplomaType_ShouldThrowException()
        {
            var studyCourseRequest = new StudyCourseRequest
            {
                DiplomaType = "InvalidDiplomaType"
            };

            Assert.Throws<ArgumentException>(() => new StudyCourse(studyCourseRequest));
        }

        [Test]
        public void Constructor_WithInvalidLocation_ShouldThrowException()
        {
            var studyCourseRequest = new StudyCourseRequest
            {
                Location = "InvalidLocation"
            };

            Assert.Throws<ArgumentException>(() => new StudyCourse(studyCourseRequest));
        }

        [Test]
        public void SetProperty_WithValidValue_ShouldSetProperty()
        {
            var studyCourse = new StudyCourse();

            studyCourse.School = "University of ABC";

            Assert.AreEqual("University of ABC", studyCourse.School);
        }

        [Test]
        public void SetProperty_WithNullValue_ShouldThrowException()
        {
            var studyCourse = new StudyCourse();

            Assert.Throws<BusinessException>(() => studyCourse.School = null);
        }

        [Test]
        public void SetProperty_WithInvalidDiplomaType_ShouldThrowException()
        {
            var studyCourse = new StudyCourse();

            Assert.Throws<BusinessException>(() => studyCourse.DiplomaType = (Diploma)100);
        }

        [Test]
        public void SetProperty_WithInvalidLocation_ShouldThrowException()
        {
            var studyCourse = new StudyCourse();

            Assert.Throws<BusinessException>(() => studyCourse.Location = (Location)100);
        }

        [Test]
        public void SetProperty_JobRelationLessThanOne_ShouldThrowException()
        {
            var studyCourse = new StudyCourse();
            Assert.Throws<BusinessException>(() => studyCourse.JobRelation = 0);
        }
    }
}
