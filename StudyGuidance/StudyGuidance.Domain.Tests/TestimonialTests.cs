using NUnit.Framework;
using StudyGuidance.Domain.Exceptions;
using StudyGuidance.Domain.Models;

namespace StudyGuidance.Domain.Tests
{
    [TestFixture]
    public class TestamonialTests
    {
        [Test]
        public void Constructor_ValidArguments_ShouldNotThrowException()
        {
            var testimonialRequest = new TestimonialRequest
            {
                Name = "John Doe",
                Description = "A great testimonial.",
                JobTitel = "Software Engineer"
            };
            Assert.That(() => new Testamonial(testimonialRequest, 1), Throws.Nothing);
        }

        [TestCase(null, "Description", "JobTitel")]
        [TestCase("Name", null, "JobTitel")]
        [TestCase("Name", "Description", null)]
        [TestCase(null, null, null)]
        public void Constructor_NullOrEmptyArgument_ShouldThrowBusinessException(string name, string description, string jobTitel)
        {
            var testimonialRequest = new TestimonialRequest
            {
                Name = name,
                Description = description,
                JobTitel = jobTitel
            };
            Assert.That(() => new Testamonial(testimonialRequest, 1), Throws.TypeOf<BusinessException>());
        }

        [Test]
        public void Name_SetValidName_ShouldNotThrowException()
        {
            var testamonial = new Testamonial();
            Assert.That(() => testamonial.Name = "John Doe", Throws.Nothing);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Name_SetNullOrEmptyName_ShouldThrowBusinessException(string name)
        {
            var testamonial = new Testamonial();
            Assert.That(() => testamonial.Name = name, Throws.TypeOf<BusinessException>());
        }

        [Test]
        public void Description_SetValidDescription_ShouldNotThrowException()
        {
            var testamonial = new Testamonial();
            Assert.That(() => testamonial.Description = "A great testimonial.", Throws.Nothing);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Description_SetNullOrEmptyDescription_ShouldThrowBusinessException(string description)
        {
            var testamonial = new Testamonial();
            Assert.That(() => testamonial.Description = description, Throws.TypeOf<BusinessException>());
        }

        [Test]
        public void JobTitel_SetValidJobTitel_ShouldNotThrowException()
        {
            var testamonial = new Testamonial();
            Assert.That(() => testamonial.JobTitel = "Software Engineer", Throws.Nothing);
        }

        [TestCase(null)]
        [TestCase("")]
        public void JobTitel_SetNullOrEmptyJobTitel_ShouldThrowBusinessException(string jobTitel)
        {
            var testamonial = new Testamonial();
            Assert.That(() => testamonial.JobTitel = jobTitel, Throws.TypeOf<BusinessException>());
        }

    }
}

