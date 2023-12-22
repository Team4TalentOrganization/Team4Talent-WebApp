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
    public class QuestionServiceTests
    {
        private QuestionService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new QuestionService();
        }

        [Test]
        public async Task AddUntilFourOptionsPerQuestion_ReturnsAllQuestionsWithFourOptions()
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
            var modifiedQuestions = _service.AddUntilFourOptionsPerQuestion(questions);

            // Assert
            Assert.IsNotNull(modifiedQuestions);
            Assert.That(2, Is.EqualTo(modifiedQuestions.Count));
            Assert.IsTrue(modifiedQuestions.All(q => q.Options.Count == 4));
        }
        [Test]
        public void AddUntilFourOptionsPerQuestion_WhenOptionsCountGreaterThanFour_CreatesNewQuestions()
        {
            // Arrange
            var questions = new List<Question>
    {
        new Question
        {
            QuestionId = 1,
            Phrase = "Question 1",
            Options = new List<Option>
            {
                new Option { OptionId = 1, Content = "Option 1" },
                new Option { OptionId = 2, Content = "Option 2" },
                new Option { OptionId = 3, Content = "Option 3" },
                new Option { OptionId = 4, Content = "Option 4" },
                new Option { OptionId = 5, Content = "Option 5" },  // Add more options
                new Option { OptionId = 6, Content = "Option 6" },
                new Option { OptionId = 7, Content = "Option 7" },
                new Option { OptionId = 8, Content = "Option 8" }
            }
        }
    };

            // Act
            var modifiedQuestions = _service.AddUntilFourOptionsPerQuestion(questions);

            // Assert
            Assert.IsNotNull(modifiedQuestions);
            Assert.That(modifiedQuestions.Count, Is.EqualTo(2));  // Two questions are expected now

            var firstQuestion = modifiedQuestions[0];
            var secondQuestion = modifiedQuestions[1];

            Assert.That(firstQuestion.Options.Count, Is.EqualTo(4));
            Assert.That(secondQuestion.Options.Count, Is.EqualTo(4));
        }
    }
}
