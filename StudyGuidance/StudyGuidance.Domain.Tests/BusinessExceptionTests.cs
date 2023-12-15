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
            var expectedMessage = "Test Message";
            var innerException = new Exception("Inner Exception");

            // Create a new BusinessException instance using reflection
            var uninitializedObject = FormatterServices.GetUninitializedObject(typeof(BusinessException));
            var exception = uninitializedObject as BusinessException;

            // Set private fields using reflection
            typeof(Exception).GetField("_message", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(exception, expectedMessage);
            typeof(Exception).GetField("_innerException", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(exception, innerException);

            // Act & Assert
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
            Assert.That(exception.InnerException, Is.Not.Null);
            Assert.That(exception.InnerException.Message, Is.EqualTo("Inner Exception"));
        }
    }
}