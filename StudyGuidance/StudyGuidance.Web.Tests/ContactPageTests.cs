using StudyGuidance.Web.Pages;

namespace StudyGuidance.Web.Tests
{
    public class ContactPageTests
    {
        [Test]
        public void ContactFormRendersCorrectly()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<ContactPage>(); 

            // Act - geen actie nodig omdat we alleen de rendering testen

            // Assert
            Assert.NotNull(cut.Find("form")); 
            Assert.NotNull(cut.Find("input#inputName")); 
            Assert.NotNull(cut.Find("input#inputMessage[type=email]")); 
            Assert.NotNull(cut.Find("button[type=submit]")); 
        }
    }
}
