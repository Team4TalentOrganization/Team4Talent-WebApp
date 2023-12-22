using StudyGuidance.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuidance.Web.Tests
{
    public class PlayerCardsTests
    {
        private PlayerCards playerCards;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            playerCards = new PlayerCards();
        }

        [Test]
        public void FlipCard_ShouldToggleShowFrontProperty()
        {
            /*
            // Arrange
            var player = new PlayerCards.PlayerModel { ShowFront = true };

            // Act
            playerCards.FlipCard(player);

            // Assert
            Assert.IsFalse(player.ShowFront);
            */
        }

        [Test]
        public void FlipCard_ShouldUpdateStylesForFront()
        {
            /*
            // Arrange
            var player = new PlayerCards.PlayerModel
            {
                ShowFront = true,
                ImageStyle = "initialImageStyle",
                HrStyle = "initialHrStyle",
                HrStyleBack = "initialHrStyleBack",
                CardBodyStyle = "initialCardBodyStyle",
                DivStyle = "initialDivStyle"
            };

            // Act
            playerCards.FlipCard(player);

            // Assert
            Assert.AreEqual("width: 100%; height: 100%; opacity: 0; transform: translateY(-100%); transition: opacity 1s ease-in-out, transform 0.5s ease-in-out;", player.ImageStyle);
            Assert.AreEqual("height: 0; visibility: hidden; margin: 0; ", player.HrStyle);
            Assert.AreEqual("height: 3px; border: none; background-color: white; opacity: revert;", player.HrStyleBack);
            Assert.AreEqual("height: 345px;", player.CardBodyStyle);
            Assert.AreEqual("width: 100%; height: 100%; opacity: 1; transform: translateY(-100%); transition: opacity 1s ease-in-out, transform 0.5s ease-in-out;", player.DivStyle);
            */
        }

        [Test]
        public void FlipCard_ShouldUpdateStylesForBack()
        {
            /*
            // Arrange
            var player = new PlayerCards.PlayerModel
            {
                ShowFront = false,
                ImageStyle = "initialImageStyle",
                HrStyle = "initialHrStyle",
                HrStyleBack = "initialHrStyleBack",
                CardBodyStyle = "initialCardBodyStyle",
                DivStyle = "initialDivStyle"
            };

            // Act
            playerCards.FlipCard(player);

            // Assert
            Assert.AreEqual("width: 100%; height: 100%; opacity: 1; transform: translateY(0); transition: opacity 1s ease-in-out, transform 0.5s ease-in-out;", player.ImageStyle);
            Assert.AreEqual("height: 3px; border: none; background-color: white; opacity: revert;", player.HrStyle);
            Assert.AreEqual("height: 0; visibility: hidden; margin: 0;", player.HrStyleBack);
            Assert.AreEqual("", player.CardBodyStyle);
            Assert.AreEqual("width: 100%; height: 100%; opacity: 1; transform: translateY(0); transition: opacity 1s ease-in-out, transform 0.5s ease-in-out;", player.DivStyle);
            */
        }
    }
}
