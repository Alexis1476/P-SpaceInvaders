using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace P_SpaceInvaders.Tests
{
    [TestClass]
    public class P_SpaceInvadersTests
    {
        [TestMethod]
        public void IsPlaying_With_Ship_Null_Result_False()
        {
            // Arrange
            Game game = new Game(200, 200, 20);
            game.Ship = null;

            // Act
            bool result = game.IsPlaying();

            // Assert
            Assert.AreEqual(false, result, "Le résultat doit être false");
        }
        [TestMethod]
        public void IsPlaying_With_Ship_Not_Null_Result_True()
        {
            // Arrange
            Game game = new Game(200, 200, 20);

            // Act
            bool result = game.IsPlaying();

            // Assert
            Assert.AreEqual(true, result, "Le résultat doit être true");
        }
        [TestMethod]
        public void IsPlaying_With_0_Invaders_Result_False()
        {
            // Arrange
            Game game = new Game(200, 200, 20);
            game.Invaders.Clear();

            // Act
            bool result = game.IsPlaying();

            // Assert
            Assert.AreEqual(false, result, "Le résultat doit être false");
        }
        [TestMethod]
        public void IsPlaying_With_Invaders_Not_Null_Result_True()
        {
            // Arrange
            Game game = new Game(200, 200, 20);

            // Act
            bool result = game.IsPlaying();

            // Assert
            Assert.AreEqual(true, result, "Le résultat doit être true");
        }
    }
}
