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
    }
}
