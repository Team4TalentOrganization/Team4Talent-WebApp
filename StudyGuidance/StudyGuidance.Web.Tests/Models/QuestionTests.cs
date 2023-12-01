using NUnit.Framework;
using StudyGuidance.Web.Models;
using System.Collections.Generic;

namespace StudyGuidance.Tests.Models
{
    public class QuestionTests
    {
        [Test]
        public void QuestionProperties_DefaultValues_ShouldBeInitialized()
        {
            var question = new Question();

            Assert.AreEqual(0, question.QuestionId);
            Assert.IsNull(question.Phrase);
        }

        [Test]
        public void QuestionProperties_SetValues_ShouldReturnCorrectValues()
        {
            var options = new List<Option>
            {
                new Option { Content = "A", OptionRelation = 1, QuestionId = 123, OptionId = 456 },
                new Option { Content = "B", OptionRelation = 2, QuestionId = 123, OptionId = 457 }
            };

            var question = new Question
            {
                Options = options,
                QuestionId = 123,
                Phrase = "Choose the correct option."
            };

            Assert.AreEqual(options, question.Options);
            Assert.AreEqual(123, question.QuestionId);
            Assert.AreEqual("Choose the correct option.", question.Phrase);
        }

        
        [Test]
        public void QuestionEquality_DifferentProperties_ShouldNotBeEqual()
        {
            var options1 = new List<Option>
            {
                new Option { Content = "A", OptionRelation = 1, QuestionId = 123, OptionId = 456 },
                new Option { Content = "B", OptionRelation = 2, QuestionId = 123, OptionId = 457 }
            };

            var options2 = new List<Option>
            {
                new Option { Content = "C", OptionRelation = 3, QuestionId = 789, OptionId = 101 },
                new Option { Content = "D", OptionRelation = 4, QuestionId = 789, OptionId = 102 }
            };

            var question1 = new Question
            {
                Options = options1,
                QuestionId = 123,
                Phrase = "Choose the correct option."
            };

            var question2 = new Question
            {
                Options = options2,
                QuestionId = 789,
                Phrase = "Choose another option."
            };

            Assert.AreNotEqual(question1, question2);
        }
    }
}

