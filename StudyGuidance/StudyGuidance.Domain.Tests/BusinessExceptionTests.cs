using StudyGuidance.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Tests
{
    public class BusinessExceptionTests
    {
        [Test]
        public void DefaultConstructor_ShouldCreateInstance()
        {
            BusinessException exception = new BusinessException();
            Assert.That(exception, Is.Not.Null);
        }

        [Test]
        public void MessageConstructor_ShouldSetMessage()
        {
            string expectedMessage = "Test Message";
            BusinessException exception = new BusinessException(expectedMessage);
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void MessageAndInnerExceptionConstructor_ShouldSetMessageAndInnerException()
        {
            string expectedMessage = "Test Message";
            Exception innerException = new Exception("Inner Exception");

            BusinessException exception = new BusinessException(expectedMessage, innerException);

            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
            Assert.That(exception.InnerException, Is.EqualTo(innerException));
        }

        [Test]
        public void SerializationConstructor_ShouldCreateInstance()
        {
            // Arrange
            var serializationInfo = new SerializationInfo(typeof(Exception), new FormatterConverter());
            var streamingContext = new StreamingContext();

            // Act
            BusinessException exception = new BusinessException("Test Message", new Exception("Inner Exception"));

            // Assert
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo("Test Message"));
            Assert.That(exception.InnerException, Is.Not.Null);
            Assert.That(exception.InnerException.Message, Is.EqualTo("Inner Exception"));
        }
    }
}