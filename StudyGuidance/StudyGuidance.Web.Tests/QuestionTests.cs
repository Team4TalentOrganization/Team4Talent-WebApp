using StudyGuidance.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Web.Tests
{
	public class QuestionTests
	{
		[Test]
		public void Question_SetOptions_OptionsHasBeenSet()
		{
			// Arrange
			var question = new Question();
			var expectedOptions = new List<Option>
			{
				new Option { OptionId = 1, Content = "Option 1", OptionRelation = 10, QuestionId = 100 },
				new Option { OptionId = 2, Content = "Option 2", OptionRelation = 20, QuestionId = 100 }
                // Add more options as needed for testing scenarios
            };

			// Act
			question.Options = expectedOptions;

			// Assert
			Assert.AreEqual(expectedOptions, question.Options);
		}

		[Test]
		public void Question_SetQuestionId_QuestionIdHasBeenSet()
		{
			// Arrange
			var question = new Question();
			int expectedQuestionId = 42;

			// Act
			question.QuestionId = expectedQuestionId;

			// Assert
			Assert.AreEqual(expectedQuestionId, question.QuestionId);
		}

		[Test]
		public void Question_SetPhrase_PhraseHasBeenSet()
		{
			// Arrange
			var question = new Question();
			string expectedPhrase = "Sample question phrase";

			// Act
			question.Phrase = expectedPhrase;

			// Assert
			Assert.AreEqual(expectedPhrase, question.Phrase);
		}
	}
}
