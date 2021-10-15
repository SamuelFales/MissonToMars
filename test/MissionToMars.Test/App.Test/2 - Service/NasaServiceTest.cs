using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissionToMars.Service;

namespace MissionToMars.Test.App.Test.Service
{
    [TestClass]
    public class NasaServiceTest
    {
        [TestMethod]
        public void NasaServiceTest_ProcessCommand_SetupPlateau_ShouldHavePlateauON()
        {
            //Arrange
            var nasa = new NasaService();
            var setupPlateauCommand = "5 5";
            //Act
            nasa.ProcessCommand(setupPlateauCommand);
            //Assert
            Assert.IsNotNull(nasa.PlateauOnMars);
            Assert.AreEqual(nasa.PlateauOnMars.CoordenateX, 5);
            Assert.AreEqual(nasa.PlateauOnMars.CoordenateY, 5);

        }

        [TestMethod]
        public void NasaServiceTest_ProcessCommand_SendRover_ShouldAddRoverOnMars()
        {
            //Arrange
            var nasa = new NasaService();
            var sendRoverCommand = "1 2 N";
            //Act
            nasa.ProcessCommand(sendRoverCommand);
            //Assert
            Assert.IsNotNull(nasa.RoverOnLine);
            Assert.IsTrue(nasa.RoversOnMars.Count == 1);
        }

        [TestMethod]
        public void NasaServiceTest_ProcessCommand_Explore_ShouldGoRigthPosition()
        {
            //Arrange
            var nasa = new NasaService();
            var sendRoverCommand = "1 2 N";
            nasa.ProcessCommand(sendRoverCommand);

            //Act
            var sendExploreCommand = "LMLMLMLMM";
            nasa.ProcessCommand(sendExploreCommand);
          
            //Assert
            Assert.IsTrue(nasa.RoverOnLine.Status == "ON");
            Assert.AreEqual(nasa.RoverOnLine.Position.X, 1);
            Assert.AreEqual(nasa.RoverOnLine.Position.Y, 3);
            Assert.AreEqual(nasa.RoverOnLine.Position.Orientation, 'N');
        }

        [TestMethod]
        public void NasaServiceTest_ProcessCommand_Explore_WrongCommand_ShouldHaveStatusOFF()
        {
            //Arrange
            var nasa = new NasaService();
            var sendRoverCommand = "1 2 N";
            nasa.ProcessCommand(sendRoverCommand);
            var setupPlateauCommand = "5 5";
            nasa.ProcessCommand(setupPlateauCommand);

            //Act
            var sendExploreCommand = "MMMMMMMMMMMM";
            nasa.ProcessCommand(sendExploreCommand);

            //Assert
            Assert.IsTrue(nasa.RoverOnLine.Status == "OFF");
       
        }

    }
}
