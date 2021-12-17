///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Tests unitaires du projet P_SpaceInvaders
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P_SpaceInvaders.GameObjects;

/// <summary>
/// Tests unitaires du projet P_SpaceInvaders
/// </summary>
namespace P_SpaceInvaders.Tests
{
    /// <summary>
    /// Class qui contient les tests unitaires du projet
    /// </summary>
    [TestClass]
    public class P_SpaceInvadersTests
    {
        /// <summary>
        /// Test methode Game.IsPlaying() lorsque le vaisseau est mort
        /// </summary>
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
        /// <summary>
        /// Test méthode Game.IsPlaying() lorsque le vaisseau est en vie
        /// </summary>
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
        /// <summary>
        /// Test méthode Game.IsPlaying() lorsqu'il n'y a plus d'invaders
        /// </summary>
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
        /// <summary>
        /// Test méthode Game.IsPlaying() lorsque il y a des invaders
        /// </summary>
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
        /// <summary>
        /// Test méthode GameObject.IsInMap() lorsque le vaisseau sort de la map
        /// </summary>
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
        /// <summary>
        /// Test méthode GameObject.IsInMap() lorsque le vaisseau se trouve à l'interieur de la map
        /// </summary>
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
        /// <summary>
        /// Test méthode GameObject.IsAtCoordinates(int,int) lorsque le vaisseau se trouve à une position donnée
        /// </summary>
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
        /// <summary>
        /// Test méthode GameObject.IsAtCoordinates(int,int) lorsque le vaisseau ne se trouve pas à une position donnée
        /// </summary>
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
        /// <summary>
        /// Test méthode GameObject.CalculateDimensions() lorsque l'objet a 5 caractères de largeur
        /// </summary>
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
        /// <summary>
        /// Test méthode GameObject.CalculateDimensions() lorsque l'objet a 1 caractère de hauteur
        /// </summary>
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
        /// <summary>
        /// Test méthode Ship.Move(Direction) vers la gauchee
        /// </summary>
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
        /// <summary>
        /// Test méthode Invader.Move(Direction) vers le bas
        /// </summary>
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
        /// <summary>
        /// Test méthode Invader.Fire() test de la position initiale de la balle en X
        /// </summary>
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
        /// <summary>
        /// Test méthode Invader.Fire() test de la position initiale de la balle en Y
        /// </summary>
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
        /// <summary>
        /// Test méthode Ship.Fire() test de la position initiale de la balle en X
        /// </summary>
        [TestMethod]
        public void Ship_Fire_With_ValuePosX_0_And_WidthChars_3_Result_1()
        {
            // Arrange
            Game game = new Game(50, 50, 5);
            Ship ship = new Ship(game, "█x█", 3);
            ship.PosX = 0;

            // Act
            ship.Fire();
            int result = game.Bullets[0].PosX;

            // Assert
            Assert.AreEqual(1, result, "Le résultat doit être 1");
        }
        /// <summary>
        /// Test méthode Ship.Fire() test de la position initiale de la balle en Y
        /// </summary>
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
