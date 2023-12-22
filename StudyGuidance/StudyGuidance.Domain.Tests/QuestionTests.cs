using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using StudyGuidance.Domain.Exceptions;
using StudyGuidance.Domain.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Tests
{
    public class QuestionTests
    {
        private int _questionId;
        private List<Option> _options = null!;
        private string _phrase = null!;
        private Random _random = new Random();

        [SetUp]
        public void BeforeEachTest()
        {
            _questionId = _random.Next();
            _options = new List<Option> { new OptionBuilder().Build(), new OptionBuilder().Build(), };
            _phrase = _random.NextDouble().ToString();
        }

        [Test]
        public void CreateNewQuestion_ValidInput_ShouldInitializeFieldsCorrectly()
        {
            Question question = new Question
            {
                QuestionId = _questionId,
                Options = _options,
                Phrase = _phrase
            };

            Assert.That(question.QuestionId, Is.EqualTo(_questionId));
            Assert.That(question.Options, Is.EqualTo(_options));
            Assert.That(question.Phrase, Is.EqualTo(_phrase));
        }

        [TestCase(null)]
        public void CreateNewQuestion_InvalidOptions_shouldThrowBusinesssException(List<Option> emptyOptions)
        {
            Question question = new Question();

            Assert.That(() => question.Options = emptyOptions, Throws.InstanceOf<BusinessException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewQuestion_InvalidPhrase_shouldThrowBusinesssException(string emptyPhrase)
        {
            Question question = new Question();

            Assert.That(() => question.Phrase = emptyPhrase, Throws.InstanceOf<BusinessException>());
        }

        [Test]
        public void SetQuestionType_InvalidValue_ShouldThrowBusinessException()
        {
            Question question = new Question();

            Assert.That(() => question.QuestionType = (QuestionType)100, Throws.InstanceOf<BusinessException>());
        }
    }

}
