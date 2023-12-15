using StudyGuidance.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Web.Tests
{
    public class HomePageHeroeTests
    {
        [Test]
        public void Should_Set_Default_Values()
        {
            // Arrange
            var homepageHeroe = new HomepageHeroe();

            // Act

            // Assert
            Assert.NotNull(homepageHeroe._source);
            Assert.AreEqual(3, homepageHeroe._source.Count);
            Assert.NotNull(homepageHeroe._text);
            Assert.AreEqual(3, homepageHeroe._text.Count);
            Assert.AreEqual(0, homepageHeroe.selectedIndex);
        }
    }
}
