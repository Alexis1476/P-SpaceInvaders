using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace P_SpaceInvaders.Tests
{
    [TestClass]
    public class P_SpaceInvadersTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Game game = new Game(200, 200, 20);
        }
    }
}
