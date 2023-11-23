using StudyGuidance.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Domain.Tests
{
    public class JobTests
    {
        private string _name;
        private string _domain;
        private string _subDomain;
        private string _description;
        private int _jobId;
        private Random _random = new Random();

        [SetUp]
        public void BeforeEachTest()
        {
            _name = Guid.NewGuid().ToString();
            _domain = Guid.NewGuid().ToString();
            _subDomain = Guid.NewGuid().ToString();
            _description = Guid.NewGuid().ToString();
            _jobId = _random.Next();
        }

        [Test]
        public void CreateNewJob_ValidInput_ShouldInitializeFieldsCorrectly()
        {
            Job job = new Job
            {
                Name = _name,
                Domain = _domain,
                SubDomain = _subDomain,
                Description = _description,
                JobId = _jobId
            };

            Assert.That(job.Name, Is.EqualTo(_name));
            Assert.That(job.Domain, Is.EqualTo(_domain));
            Assert.That(job.SubDomain, Is.EqualTo(_subDomain));
            Assert.That(job.Description, Is.EqualTo(_description));
            Assert.That(job.JobId, Is.EqualTo(_jobId));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewName_InvalidName_ShouldThrowBusinessException(string emptyName)
        {
            Job job = new Job();

            Assert.That(() => job.Name = emptyName, Throws.InstanceOf<BusinessException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewDomain_InvalidDomain_ShouldThrowBusinessException(string emptyDomain)
        {
            Job job = new Job();

            Assert.That(() => job.Domain = emptyDomain, Throws.InstanceOf<BusinessException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewSubDomain_InvalidSubDomain_ShouldThrowBusinessException(string emptySubDomain)
        {
            Job job = new Job();

            Assert.That(() => job.SubDomain = emptySubDomain, Throws.InstanceOf<BusinessException>());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateNewDescription_InvalidDescription_ShouldThrowBusinessException(string emptyDescription)
        {
            Job job = new Job();

            Assert.That(() => job.Description = emptyDescription, Throws.InstanceOf<BusinessException>());
        }
    }
}
