using StudyGuidance.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Tests
{
    public class RecruiterTests
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _company;
        private int _recruiterId;
        private Random _random = new Random();

        [SetUp]
        public void BeforeEachTest()
        {
            _firstName = Guid.NewGuid().ToString();
            _lastName = Guid.NewGuid().ToString();
            _email = Guid.NewGuid().ToString();
            _company = Guid.NewGuid().ToString();
            _recruiterId = _random.Next();
        }

        [Test]
        public void CreateNewRecruiter_ValidInput_ShouldInitializeFieldsCorrectly()
        {
            Recruiter recruiter = new Recruiter
            {
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email,
                Company = _company,
                RecruiterId = _recruiterId
            };

            Assert.That(recruiter.FirstName, Is.EqualTo(_firstName));
            Assert.That(recruiter.LastName, Is.EqualTo(_lastName));
            Assert.That(recruiter.Email, Is.EqualTo(_email));
            Assert.That(recruiter.Company, Is.EqualTo(_company));
            Assert.That(recruiter.RecruiterId, Is.EqualTo(_recruiterId));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewFirstName_InvalidFirstName_ShouldThrowBusinessException(string emptyFirstName)
        {
            Recruiter recruiter = new Recruiter();

            Assert.That(() => recruiter.FirstName = emptyFirstName, Throws.InstanceOf<BusinessException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewLastName_InvalidLastName_ShouldThrowBusinessException(string emptyLastName)
        {
            Recruiter recruiter = new Recruiter();

            Assert.That(() => recruiter.LastName = emptyLastName, Throws.InstanceOf<BusinessException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewEmail_InvalidEmail_ShouldThrowBusinessException(string emptyEmail)
        {
            Recruiter recruiter = new Recruiter();

            Assert.That(() => recruiter.Email = emptyEmail, Throws.InstanceOf<BusinessException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewCompany_InvalidCompany_ShouldThrowBusinessException(string emptyCompany)
        {
            Recruiter recruiter = new Recruiter();

            Assert.That(() => recruiter.Company = emptyCompany, Throws.InstanceOf<BusinessException>());
        }
    }
}
