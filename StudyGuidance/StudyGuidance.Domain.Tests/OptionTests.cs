using StudyGuidance.Domain.Exceptions;
using StudyGuidance.Domain.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Tests
{
    public class OptionTests
    {
        private int _optionId;
        private int _questionId;
        private int _optionRelation;
        private string _content = null!;
        private bool _isChecked = false;
        private Random _random = new Random();

        [SetUp]
        public void BeforeEachTest()
        {
            _optionId = _random.Next();
            _questionId = _random.Next();
            _optionRelation = _random.Next();
            _content = _random.NextDouble().ToString();
        }

        [Test]
        public void CreateNewOption_ValidInput_ShouldInitializeFieldsCorrectly()
        {
            Option option = new Option
            {
                OptionId = _optionId,
                QuestionId = _questionId,
                OptionRelation = _optionRelation,
                Content = _content,
                IsChecked = _isChecked,
            };

            Assert.That(option.QuestionId, Is.EqualTo(_questionId));
            Assert.That(option.OptionId, Is.EqualTo(_optionId));
            Assert.That(option.Content, Is.EqualTo(_content));
            Assert.That(option.OptionRelation, Is.EqualTo(_optionRelation));
            Assert.That(option.IsChecked, Is.EqualTo(_isChecked));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewOption_InvalidContent_ShouldThrowBusinessException(string emptyContent)
        {
            Option option = new Option();

            Assert.That(() => option.Content = emptyContent, Throws.InstanceOf<BusinessException>());
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void CreateNewOption_InvalidOptionRelation_ShouldThrowBusinessException(int emptyOptionRelation)
        {
            Option option = new Option();

            Assert.That(() => option.OptionRelation = emptyOptionRelation, Throws.InstanceOf<BusinessException>());
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void CreateNewOption_InvalidQuestionId_ShouldThrowBusinessException(int emptyQuestionId)
        {
            Option option = new Option();

            Assert.That(() => option.QuestionId = emptyQuestionId, Throws.InstanceOf<BusinessException>());
        }
    }
}
