using StudyGuidance.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Web.Tests
{
	public class OptionTests
	{
		[Test]
		public void Option_SetContent_ContentHasBeenSet()
		{
			// Arrange
			var option = new Option();
			string expectedContent = "Sample content";

			// Act
			option.Content = expectedContent;

			// Assert
			Assert.AreEqual(expectedContent, option.Content);
		}

		[Test]
		public void Option_SetOptionRelation_OptionRelationHasBeenSet()
		{
			// Arrange
			var option = new Option();
			int expectedOptionRelation = 42;

			// Act
			option.OptionRelation = expectedOptionRelation;

			// Assert
			Assert.AreEqual(expectedOptionRelation, option.OptionRelation);
		}

		[Test]
		public void Option_SetQuestionId_QuestionIdHasBeenSet()
		{
			// Arrange
			var option = new Option();
			int expectedQuestionId = 10;

			// Act
			option.QuestionId = expectedQuestionId;

			// Assert
			Assert.AreEqual(expectedQuestionId, option.QuestionId);
		}

		[Test]
		public void Option_SetOptionId_OptionIdHasBeenSet()
		{
			// Arrange
			var option = new Option();
			int expectedOptionId = 5;

			// Act
			option.OptionId = expectedOptionId;

			// Assert
			Assert.AreEqual(expectedOptionId, option.OptionId);
		}
	}
}
