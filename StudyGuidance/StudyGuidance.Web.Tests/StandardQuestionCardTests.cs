using Microsoft.JSInterop;
using Moq;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Models;
using StudyGuidance.Web.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudyGuidance.Web.Tests
{
    public class StandardQuestionCardTests
    {
        [Test]
        public async Task MouseOver_Should_Update_CardClass()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();

            // Act
            await standardQuestionCard.MouseOver(0);

            // Assert
            Assert.That(standardQuestionCard.CardClasses[0], Does.Contain("bg-orange-color"));
        }

        [Test]
        public async Task MouseOut_Should_Update_CardClass()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();

            // Act
            await standardQuestionCard.MouseOut(0);

            // Assert
            Assert.That(standardQuestionCard.CardClasses[0], Does.Not.Contain("bg-orange-color"));
        }

        [Test]
        public void CardClicked_Should_Toggle_CardClass()
        {
            // Arrange
            var quizApiClientMock = new Mock<IQuizApiClient>();
            var standardQuestionCard = new StandardQuestionCard { QuizApiClient = quizApiClientMock.Object };

            // Set up a sample question
            var sampleQuestion = new Question
            {
                QuestionId = 1,
                Phrase = "In welk domein heb je interesse?",
                Options = new List<Option>
                {
                    new Option { OptionId = 1, Content = "AI", QuestionId = 1 },
                    new Option { OptionId = 2, Content = "Development", QuestionId = 1 },
                    new Option { OptionId = 3, Content = "Software Management", QuestionId = 1 },
                    new Option { OptionId = 4, Content = "Systeem en netwerkbeheer", QuestionId = 1 }
                },
            };

            standardQuestionCard.questionsList = new List<Question> { sampleQuestion };

            // Act
            standardQuestionCard.CardClicked(0);
            var initialClass = standardQuestionCard.CardClasses[0];
            standardQuestionCard.CardClicked(0);
            var toggledClass = standardQuestionCard.CardClasses[0];

            // Assert
            Assert.AreNotEqual(initialClass, toggledClass);
        }

        [Test]
        public void GetOptionsForCurrentQuestion_Should_Return_Options()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();

            // Create a domainQuestion for testing
            var domainQuestion = new Question
            {
                QuestionId = 1,
                Phrase = "In welk domein heb je interesse?",
                Options = new List<Option>
                {
                    new Option { OptionId = 1, Content = "AI", QuestionId = 1 },
                    new Option { OptionId = 2, Content = "Development", QuestionId = 1 },
                    new Option { OptionId = 3, Content = "Software Management", QuestionId = 1 },
                    new Option { OptionId = 4, Content = "Systeem en netwerkbeheer", QuestionId = 1 }
                },
            };

            standardQuestionCard.questionsList.Add(domainQuestion);

            // Act
            var options = standardQuestionCard.GetOptionsForCurrentQuestion();

            // Assert
            Assert.AreEqual(4, options.Count);
            Assert.Contains("AI", options);
        }

        [Test]
        public void NextQuestionClicked_Should_Update_DomainAnswers()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();
            standardQuestionCard.questionsList.Add(new Question
            {
                Options = new List<Option>
                {
                    new Option { OptionId = 1 },
                    new Option { OptionId = 2 },
                    new Option { OptionId = 3 },
                    new Option { OptionId = 4 }
                }
            });
            standardQuestionCard.CardClasses = new string[] { "card text-white bg-orange-color-click h-50 mb-3", "", "", "" };

            // Act
            standardQuestionCard.NextQuestionClicked();

            // Assert
            Assert.AreEqual(1, standardQuestionCard.domainAnswers.Count);
            Assert.AreEqual(1, standardQuestionCard.domainAnswers[0]);
        }

        [Test]
        public void NextQuestionClicked_Should_Update_SubDomainAnswers_When_SubDomainsAreSet()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();
            standardQuestionCard.subDomainsAreSet = true;
            standardQuestionCard.questionsList.Add(new Question
            {
                Options = new List<Option>
                {
                    new Option { OptionId = 1 },
                    new Option { OptionId = 2 },
                    new Option { OptionId = 3 },
                    new Option { OptionId = 4 }
                }
            });
            standardQuestionCard.CardClasses = new string[] { "card text-white bg-orange-color-click h-50 mb-3", "", "", "" };

            // Act
            standardQuestionCard.NextQuestionClicked();

            // Assert
            Assert.AreEqual(1, standardQuestionCard.subDomainAnswers.Count);
            Assert.AreEqual(1, standardQuestionCard.subDomainAnswers[0]);
        }

        [Test]
        public void PreviousQuestionClicked_Should_Decrement_CurrentQuestion()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();
            standardQuestionCard.currentQuestion = 2;

            // Act
            standardQuestionCard.PreviousQuestionClicked();

            // Assert
            Assert.AreEqual(1, standardQuestionCard.currentQuestion);
        }

        [Test]
        public void PreviousQuestionClicked_Should_Reset_SubDomains_When_CurrentQuestion_Contains_Subdomain_Phrase()
        {
            // Arrange
            var domainQuestion = new Question
            {
                QuestionId = 1,
                Phrase = "In welk domein heb je interesse?",
                Options = new List<Option>
                {
                    new Option { OptionId = 1, Content = "AI", QuestionId = 1 },
                    new Option { OptionId = 2, Content = "Development", QuestionId = 1 },
                    new Option { OptionId = 3, Content = "Software Management", QuestionId = 1 },
                    new Option { OptionId = 4, Content = "Systeem en netwerkbeheer", QuestionId = 1 }
                },
            };
            var standardQuestionCard = new StandardQuestionCard();
            standardQuestionCard.currentQuestion = 1;
            standardQuestionCard.questionsList.Add(domainQuestion);
            standardQuestionCard.questionsList.Add(new Question { Phrase = "In welk subdomein heb je interesse?" });
            standardQuestionCard.subDomainsAreSet = true;

            // Act
            standardQuestionCard.PreviousQuestionClicked();

            // Assert
            Assert.IsFalse(standardQuestionCard.subDomainsAreSet);
            Assert.IsEmpty(standardQuestionCard.domainAnswers);
        }

        [Test]
        public void NextQuestionClicked_Should_Not_Update_SubDomainAnswers_When_SubDomainsAreNotSet()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();
            standardQuestionCard.subDomainsAreSet = false;
            standardQuestionCard.questionsList.Add(new Question
            {
                Options = new List<Option>
        {
            new Option { OptionId = 1 },
            new Option { OptionId = 2 },
            new Option { OptionId = 3 },
            new Option { OptionId = 4 }
        }
            });
            standardQuestionCard.CardClasses = new string[] { "card text-white bg-orange-color-click h-50 mb-3", "", "", "" };

            // Act
            standardQuestionCard.NextQuestionClicked();

            // Assert
            Assert.IsEmpty(standardQuestionCard.subDomainAnswers);
        }

        [Test]
        public void EndStandardQuiz_Should_Set_StandardQuizEnded()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();
            standardQuestionCard.CardClasses = new string[] { "", "", "", "card text-white bg-orange-color-click h-50 mb-3" };

            // Act
            standardQuestionCard.EndStandardQuiz();

            // Assert
            Assert.IsTrue(standardQuestionCard.StandardQuizEnded);
        }

        [Test]
        public void AreAnyCardsSelected_Should_Return_True_When_Cards_Are_Selected()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();
            standardQuestionCard.domainAnswers = new List<int> { 1, 2, 3, 4 };
            standardQuestionCard.currentQuestion = 1;

            // Act
            var result = standardQuestionCard.AreAnyCardsSelected();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AreAnyCardsSelected_Should_Return_False_When_No_Cards_Are_Selected()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();

            // Act
            var result = standardQuestionCard.AreAnyCardsSelected();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsOptionValueEmpty_Should_Return_True_For_Empty_Value()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();

            // Act
            var result = standardQuestionCard.IsOptionValueEmpty("");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOptionValueEmpty_Should_Return_False_For_NonEmpty_Value()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();

            // Act
            var result = standardQuestionCard.IsOptionValueEmpty("NonEmpty");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void PreviousQuestionClicked_Should_Not_Reset_SubDomains_When_CurrentQuestion_Is_Not_Subdomain_Phrase()
        {
            // Arrange
            var standardQuestionCard = new StandardQuestionCard();
            standardQuestionCard.currentQuestion = 1;
            standardQuestionCard.questionsList.Add(new Question { Phrase = "Some other question" });
            standardQuestionCard.subDomainsAreSet = true;
            standardQuestionCard.domainAnswers = new List<int> { 1, 2, 3, 4 };

            // Act
            standardQuestionCard.PreviousQuestionClicked();

            // Assert
            Assert.IsTrue(standardQuestionCard.subDomainsAreSet);
            Assert.AreEqual(4, standardQuestionCard.domainAnswers.Count);
        }

        [Test]
        public async Task NextQuestionClicked_Should_Update_DomainAnswers_When_CardClasses_Contain_Selected_Card()
        {
            // Arrange
            var quizApiClientMock = new Mock<IQuizApiClient>();
            var standardQuestionCard = SetupStandardQuestionCardWithMockAndQuestions(true, new[] { "card text-white bg-orange-color-click h-50 mb-3", "", "", "" });

            var selectedDomains = CreateSelectedDomains();

            standardQuestionCard.questionsList.Add(selectedDomains[0]);
            standardQuestionCard.questionsList.Add(selectedDomains[1]);
            standardQuestionCard.currentQuestion = 1;

            // Configure the mock to return a non-null value for GetSubdomains
            quizApiClientMock.Setup(x => x.GetSubdomains(It.IsAny<List<int>>())).ReturnsAsync(new List<Question>());

            // Act
            await standardQuestionCard.NextQuestionClicked();

            // Assert
            Assert.AreEqual(1, standardQuestionCard.domainAnswers.Count);
            Assert.AreEqual(selectedDomains[1].Options[0].OptionId, standardQuestionCard.domainAnswers[0]);
        }

        [Test]
        public async Task NextQuestionClicked_Should_Update_SubDomainAnswers_When_SubDomainsAreSet_And_CardClasses_Contain_Selected_Card()
        {
            // Arrange
            var quizApiClientMock = new Mock<IQuizApiClient>();
            var standardQuestionCard = SetupStandardQuestionCardWithMockAndQuestions(true, new[] { "card text-white bg-orange-color-click h-50 mb-3", "card text-black h-50 mb-3", "card text-black h-50 mb-3", "card text-white bg-orange-color-click h-50 mb-3" });

            var selectedDomains = CreateSelectedDomains();
            standardQuestionCard.questionsList.Add(selectedDomains[1]);
            standardQuestionCard.questionsList.Add(selectedDomains[0]);
            standardQuestionCard.currentQuestion = 1;

            quizApiClientMock.Setup(x => x.GetSubdomains(It.IsAny<List<int>>())).ReturnsAsync(selectedDomains);

            // Act
            await standardQuestionCard.NextQuestionClicked();

            // Assert
            Assert.AreEqual(2, standardQuestionCard.subDomainAnswers.Count);
            Assert.AreEqual(selectedDomains[0].Options[0].OptionId, standardQuestionCard.subDomainAnswers[0]);
            // Add additional assertions as needed
        }

        [Test]
        public async Task NextQuestionClicked_Should_Not_Update_SubDomainAnswers_When_SubDomainsAreNotSet_And_CardClasses_Contain_Selected_Card()
        {
            // Arrange
            var quizApiClientMock = new Mock<IQuizApiClient>();
            var standardQuestionCard = SetupStandardQuestionCardWithMockAndQuestions(false, new[] { "card text-white bg-orange-color-click h-50 mb-3", "", "", "" });

            var selectedDomains = CreateSelectedDomains();

            standardQuestionCard.questionsList.Add(selectedDomains[0]);
            standardQuestionCard.questionsList.Add(selectedDomains[1]);
            standardQuestionCard.currentQuestion = 1;

            // Configure the mock to return a non-null value for GetSubdomains
            quizApiClientMock.Setup(x => x.GetSubdomains(It.IsAny<List<int>>())).ReturnsAsync(new List<Question>());
            // Act
            await standardQuestionCard.NextQuestionClicked();

            // Assert
            Assert.IsEmpty(standardQuestionCard.subDomainAnswers);
        }

        [Test]
        public async Task NextQuestionClicked_Should_Update_SelectedDomains_And_Modify_QuestionsList_When_SubDomainsAreNotSet_And_LastQuestion()
        {
            // Arrange
            var quizApiClientMock = new Mock<IQuizApiClient>();
            var standardQuestionCard = new StandardQuestionCard
            {
                QuizApiClient = quizApiClientMock.Object,
                subDomainsAreSet = false,
                CardClasses = new[] { "card text-white bg-orange-color-click h-50 mb-3", "card text-black h-50 mb-3", "card text-black h-50 mb-3", "card text-white bg-orange-color-click h-50 mb-3" }
            };

            var selectedDomains = CreateSelectedDomains();

            standardQuestionCard.questionsList.Add(selectedDomains[1]);
            standardQuestionCard.questionsList.Add(selectedDomains[0]);
            standardQuestionCard.currentQuestion = 1;

            quizApiClientMock.Setup(x => x.GetSubdomains(It.IsAny<List<int>>())).ReturnsAsync(selectedDomains);

            // Act
            await standardQuestionCard.NextQuestionClicked();

            // Assert
            Assert.AreEqual(selectedDomains.Count, standardQuestionCard.selectedDomains.Count);
            Assert.IsTrue(standardQuestionCard.subDomainsAreSet);

            foreach (var question in selectedDomains)
            {
                Assert.IsTrue(standardQuestionCard.questionsList.Any(q => q.Phrase == question.Phrase));
            }
        }

        private List<Question> CreateSelectedDomains()
        {
            return new List<Question>
            {
                new Question
                {
                    Phrase = "Selected Domain 1",
                    Options = new List<Option>
                    {
                        new Option { OptionId = 5, Content = "Selected Option 1" },
                        new Option { OptionId = 6, Content = "Selected Option 2" },
                        new Option { OptionId = 7, Content = "Selected Option 1" },
                        new Option { OptionId = 8, Content = "Selected Option 2" },
                    }
                },
                new Question
                {
                    Phrase = "Selected Domain 2",
                    Options = new List<Option>
                    {
                        new Option { OptionId = 9, Content = "Selected Option 3" },
                        new Option { OptionId = 10, Content = "Selected Option 4" },
                        new Option { OptionId = 11, Content = "Selected Option 3" },
                        new Option { OptionId = 12, Content = "Selected Option 4" },
                    }
                }
            };
        }

        private StandardQuestionCard SetupStandardQuestionCardWithMockAndQuestions(bool subDomainsAreSet, string[] cardClasses)
        {
            var quizApiClientMock = new Mock<IQuizApiClient>();
            var standardQuestionCard = new StandardQuestionCard
            {
                QuizApiClient = quizApiClientMock.Object,
                subDomainsAreSet = subDomainsAreSet,
                CardClasses = cardClasses
            };

            quizApiClientMock.Setup(x => x.GetSubdomains(It.IsAny<List<int>>())).ReturnsAsync(new List<Question>());

            return standardQuestionCard;
        }


    }
}
