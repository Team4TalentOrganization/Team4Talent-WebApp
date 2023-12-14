using Microsoft.EntityFrameworkCore;
using System;
using StudyGuidance.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyGuidance.AppLogic;

namespace StudyGuidance.Infrastructure.Tests
{
    public class QuestionModificationServiceTests
    {
        private QuestionModificationService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new QuestionModificationService();
        }

        [Test]
        public async Task QuestionModification_ReturnsAllQuestionsWithFourOptions()
        {
            // Arrange
            var questions = new List<Question>
            {
                new Question { QuestionId = 1, Phrase = "Question 1" },
                new Question { QuestionId = 2, Phrase = "Question 2" }
            };

            var optionsQuestionOne = new List<Option>
            {
                new Option { OptionId = 1, Content = "Option 1", QuestionId = 1 },
                new Option { OptionId = 2, Content = "Option 2", QuestionId = 1 },
                new Option { OptionId = 3, Content = "Option 3", QuestionId = 1 },
                new Option { OptionId = 4, Content = "Option 4", QuestionId = 1 }
            };

            var optionsQuestionTwo = new List<Option>
            {
                new Option { OptionId = 5, Content = "Option 1", QuestionId = 2 },
                new Option { OptionId = 6, Content = "Option 2", QuestionId = 2 },
                new Option { OptionId = 7, Content = "Option 3", QuestionId = 2 }
            };

            questions[0].Options.AddRange(optionsQuestionOne);
            questions[1].Options.AddRange(optionsQuestionTwo);

            // Act
            var modifiedQuestions = _service.ModifyQuestions(questions);

            // Assert
            Assert.IsNotNull(modifiedQuestions);
            Assert.That(2, Is.EqualTo(modifiedQuestions.Count));
            Assert.IsTrue(modifiedQuestions.All(q => q.Options.Count == 4));
        }
    }
}
