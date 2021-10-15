
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissionToMars.Domain;
using MissionToMars.Domain.Model;

namespace MissionToMars.Test.App.Test.Model
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void RoverTests_Explore_WhenRightMoviment_ShouldGoCorrectPositions()
        {
            //Arrange
            var pos = new Position(1,2,'N');
            var rover = new Rover(pos);

            var endPosition = new Position(1, 3, 'N');

            //Act
            rover.Explore("LMLMLMLMM");

            //Assert
            Assert.IsTrue(rover.Status == "ON");
            Assert.AreEqual(rover.Position.X, endPosition.X);
            Assert.AreEqual(rover.Position.Y, endPosition.Y);
            Assert.AreEqual(rover.Position.Orientation, endPosition.Orientation);
        }

    }
}
