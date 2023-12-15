using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Moq;
using System;
using Bunit;
using StudyGuidance.Web.Shared;
using System.Threading.Tasks;

namespace StudyGuidance.Web.Tests
{
    [TestFixture]
    public class NavMenuTests : Bunit.TestContext
    {
        private NavMenu _navMenu;
        private Mock<NavigationManager> _mockNavigationManager;
        private Mock<IJSRuntime> _mockJSRuntime;

        [SetUp]
        public void SetUp()
        {
            _mockNavigationManager = new Mock<NavigationManager>();
            _mockJSRuntime = new Mock<IJSRuntime>();
            _navMenu = new NavMenu
            {
                NavigationManager = _mockNavigationManager.Object,
                JSRuntime = _mockJSRuntime.Object
            };
        }

        [Test]
        public async Task ToggleNavMenu_ShouldToggleCollapseNavMenuAndSetNavStyle()
        {
            // Arrange
            bool initialCollapseNavMenu = _navMenu.collapseNavMenu;
            string initialNavStyle = _navMenu.navStyle;

            // Act
            _navMenu.ToggleNavMenu();

            // Assert
            Assert.AreNotEqual(initialCollapseNavMenu, _navMenu.collapseNavMenu);
            Assert.AreNotEqual(initialNavStyle, _navMenu.navStyle);
        }

        [Test]
        public void Close_ShouldSetPropertiesRight()
        {
            // Arrange
            _navMenu.ModalDisplay = "block";
            _navMenu.ModalClass = "Show";
            _navMenu.ShowBackdrop = true;

            // Act
            var cut = RenderComponent<NavMenu>(
                parameters => parameters
                    .Add(p => p.NavigationManager, _mockNavigationManager.Object)
                    .Add(p => p.JSRuntime, _mockJSRuntime.Object)
            );

            cut.InvokeAsync(() => _navMenu.Close());

            // Assert
            Assert.AreEqual("none", _navMenu.ModalDisplay);
            Assert.AreEqual("", _navMenu.ModalClass);
            Assert.IsFalse(_navMenu.ShowBackdrop);
        }

        [Test]
        public void CloseAndRouteTo_ShouldSetPropertiesRightAndRouteToGivenUrl()
        {
            // Arrange
            var navMenu = new NavMenu
            {
                destinationUrl = "https://example.com/somepage",
                ModalDisplay = "none",
                ModalClass = "",
                ShowBackdrop = false
            };

            // Act
            var cut = RenderComponent<NavMenu>();

            cut.InvokeAsync(() => _navMenu.CloseAndRouteTo());

            // Assert
            Assert.AreEqual("none", navMenu.ModalDisplay);
            Assert.AreEqual("", navMenu.ModalClass);
            Assert.IsFalse(navMenu.ShowBackdrop);
        }

        [Test]
        public void Open_ShouldSetPropertiesRight()
        {
            // Arrange
            var navMenu = new NavMenu();
            var destinationUrl = "https://example.com/quiz";
            navMenu.destinationUrl = destinationUrl;
            navMenu.ModalDisplay = "block";
            navMenu.ModalClass = "Show";
            navMenu.ShowBackdrop = true;

            // Act
            var cut = RenderComponent<NavMenu>(
                parameters => parameters
                    .Add(p => p.NavigationManager, _mockNavigationManager.Object)
                    .Add(p => p.JSRuntime, _mockJSRuntime.Object)
            );

            cut.InvokeAsync(() => _navMenu.Close());
            cut.InvokeAsync(() => _navMenu.Open(destinationUrl));

            // Assert
            Assert.AreEqual(destinationUrl, navMenu.destinationUrl);
            Assert.AreEqual("block", navMenu.ModalDisplay);
            Assert.AreEqual("Show", navMenu.ModalClass);
            Assert.IsTrue(navMenu.ShowBackdrop);
        }

    }
}
