using StudyGuidance.Web.Pages;
using StudyGuidance.Web.Shared;

namespace StudyGuidance.Web.Tests
{
    public class TinderCardPageTests
    {
        [Test]
        public void TinderCardRendersCorrectly()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();
            var cut = ctx.RenderComponent<TinderQuestionCard>();

            // Act - geen actie nodig omdat we alleen de rendering testen

            // Assert
            cut.MarkupMatches(@"    <div class=""animate__animated animate__zoomIn "" style=""animation-duration: 800ms;animation-delay : 0ms;animation-iteration-count: 1;; "" >
  <div class=""container bg-custom-color text-center"" style=""width: 70%; height: 350px; position: relative; overflow: hidden; border-radius: 15px;"" >
    <div class=""w-85 h-50 mx-auto mt-5 mb-3"" >
      <img class=""w-100 h-85 mt-3 bg-custom-border"" src=""/images/tinderquestion1.jpg"" style=""border-radius: 15px;"" >
    </div>
    <p class=""text-white text-center m-0 "" style=""font-size: 20px;"" >Systeem NetwerkBeheer</p>
    <div class=""row mt-5"" >
      <div class=""col-5 mt-5"" >
        <svg  xmlns=""http://www.w3.org/2000/svg"" width=""48"" height=""48"" fill=""#FF0000"" class=""bi bi-x-circle"" viewBox=""0 0 16 16"" >
          <path d=""M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"" ></path>
          <path d=""M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708"" ></path>
        </svg>
      </div>
      <div class=""col-2"" ></div>
      <div class=""col-5 mt-5"" >
        <svg  xmlns=""http://www.w3.org/2000/svg"" width=""48"" height=""48"" fill=""#2DFF00"" class=""bi bi-check-circle"" viewBox=""0 0 16 16"" >
          <path d=""M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"" ></path>
          <path d=""M10.97 4.97a.235.235 0 0 0-.02.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-1.071-1.05"" ></path>
        </svg>
      </div>
    </div>
  </div>
</div>");
        }
    }
}
