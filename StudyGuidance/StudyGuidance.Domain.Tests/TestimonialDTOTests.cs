using NUnit.Framework;
using StudyGuidance.Domain;
using StudyGuidance.Domain.Models;

namespace StudyGuidance.Domain.Tests.Models
{
    [TestFixture]
    public class TestimonialDTOTests
    {
        [Test]
        public void Constructor_WithTestamonial_ShouldMapPropertiesCorrectly()
        {
            var testamonial = new Testamonial
            {
                Id = 1,
                JobId = 123,
                Name = "John Doe",
                Description = "A great employee",
                JobTitel = "Software Engineer"
            };

            var testimonialDTO = new TestimonialDTO(testamonial);

            Assert.AreEqual(testamonial.Id, testimonialDTO.Id);
            Assert.AreEqual(testamonial.JobId, testimonialDTO.JobId);
            Assert.AreEqual(testamonial.Name, testimonialDTO.Name);
            Assert.AreEqual(testamonial.Description, testimonialDTO.Description);
            Assert.AreEqual(testamonial.JobTitel, testimonialDTO.JobTitel);
        }

        [Test]
        public void DefaultConstructor_ShouldInitializeProperties()
        {
            var testimonialDTO = new TestimonialDTO();
            Assert.AreEqual(0, testimonialDTO.Id);
            Assert.AreEqual(0, testimonialDTO.JobId);
            Assert.IsNull(testimonialDTO.Name);
            Assert.IsNull(testimonialDTO.Description);
            Assert.IsNull(testimonialDTO.JobTitel);
        }
    }
}

