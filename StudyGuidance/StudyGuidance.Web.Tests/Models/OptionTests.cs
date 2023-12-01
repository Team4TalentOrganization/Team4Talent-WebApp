using NUnit.Framework;
using StudyGuidance.Web.Models;

namespace StudyGuidance.Tests.Models
{
    public class OptionTests
    {
        [Test]
        public void OptionProperties_DefaultValues_ShouldBeInitialized()
        {
            var option = new Option();

            Assert.IsNull(option.Content);
            Assert.AreEqual(0, option.OptionRelation);
            Assert.AreEqual(0, option.QuestionId);
            Assert.AreEqual(0, option.OptionId);
        }

        [Test]
        public void OptionProperties_SetValues_ShouldReturnCorrectValues()
        {
            var option = new Option
            {
                Content = "A",
                OptionRelation = 1,
                QuestionId = 123,
                OptionId = 456
            };

            // Assert
            Assert.AreEqual("A", option.Content);
            Assert.AreEqual(1, option.OptionRelation);
            Assert.AreEqual(123, option.QuestionId);
            Assert.AreEqual(456, option.OptionId);
        }

        [Test]
        public void OptionEquality_DifferentProperties_ShouldNotBeEqual()
        {
            var option1 = new Option
            {
                Content = "A",
                OptionRelation = 1,
                QuestionId = 123,
                OptionId = 456
            };

            var option2 = new Option
            {
                Content = "B",
                OptionRelation = 2,
                QuestionId = 789,
                OptionId = 101
            };

            Assert.AreNotEqual(option1, option2);
        }
    }
}

