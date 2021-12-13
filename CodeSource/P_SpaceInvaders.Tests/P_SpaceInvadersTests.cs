///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Tests unitaires du projet P_SpaceInvaders
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P_SpaceInvaders.GameObjects;

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
        [TestMethod]
        public void IsInMap_With_ShipPosY_Value_70_Result_false()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            game.Ship.PosY = 70;

            // Act
            bool result = game.Ship.IsInMap();

            // Assert
            Assert.AreEqual(false, result, "Le résultat doit être false");
        }
        [TestMethod]
        public void IsInMap_With_ShipPosY_Value_40_Result_true()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            game.Ship.PosY = 40;

            // Act
            bool result = game.Ship.IsInMap();

            // Assert
            Assert.AreEqual(true, result, "Le résultat doit être true");
        }
        [TestMethod]
        public void IsAtCoordinates_WithValues_30_And_40_Result_True()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            game.Ship.PosX = 30;
            game.Ship.PosY = 40;

            // Act
            bool result = game.Ship.IsAtCoordinates(30, 40);

            // Assert
            Assert.AreEqual(true, result, "Le résultat doit être true");
        }
        [TestMethod]
        public void IsAtCoordinates_WithValues_30_And_50_Result_false()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            game.Ship.PosX = 30;
            game.Ship.PosY = 40;

            // Act
            bool result = game.Ship.IsAtCoordinates(30, 50);

            // Assert
            Assert.AreEqual(false, result, "Le résultat doit être false");
        }
        [TestMethod]
        public void CalculateDimensionsObject_With_Value_12345_Result_5()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            Ship ship = new Ship(game, "12345", 3);

            // Act
            int result = ship.WidthChars;

            // Assert
            Assert.AreEqual(5, result, "Le résultat doit être 5");
        }
        [TestMethod]
        public void CalculateDimensionsObject_With_2DObject_Result_3()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            Ship ship = new Ship(game, "█\n█\n█", 3);

            // Act
            int result = ship.HeightChars;

            // Assert
            Assert.AreEqual(3, result, "Le résultat doit être 3");
        }
        [TestMethod]
        public void Move_Ship_Left_With_ValuePosX_10_Result_9()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            game.Ship.PosX = 10;

            // Act
            game.Ship.Move(Direction.Left);
            int result = game.Ship.PosX;

            // Assert
            Assert.AreEqual(9, result, "Le résultat doit être 9");
        }
        [TestMethod]
        public void Move_Invader_Down_With_ValuePosY_10_Result_12()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            Invader invader = new Invader(2, game, "█\n█");
            invader.PosY = 10;

            // Act
            invader.Move(Direction.Down);
            int result = invader.PosY;

            // Assert
            Assert.AreEqual(10 + invader.HeightChars, result, "Le résultat doit être 12");
        }
        [TestMethod]
        public void Invader_Fire_With_ValuePosX_0_And_WidthChars_3_Result_1()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            Invader invader = new Invader(2, game, "█x█");
            invader.PosX = 0;

            // Act
            invader.Fire();
            int result = game.Bullets[0].PosX;

            // Assert
            Assert.AreEqual(1, result, "Le résultat doit être 1");
        }
        [TestMethod]
        public void Invader_Fire_With_ValuePosY_1_Result_2()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            Invader invader = new Invader(2, game, "█x█");
            invader.PosY = 1;

            // Act
            invader.Fire();
            int result = game.Bullets[0].PosY;

            // Assert
            Assert.AreEqual(invader.PosY + 1, result, "Le résultat doit être 1");
        }
        [TestMethod]
        public void Ship_Fire_With_ValuePosY_10_Result_9()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            Ship ship = new Ship(game, "█x█", 3);
            ship.PosY = 10;

            // Act
            ship.Fire();
            int result = game.Bullets[0].PosY;

            // Assert
            Assert.AreEqual(ship.PosY - 1, result, "Le résultat doit être 9");
        }
    }
}
