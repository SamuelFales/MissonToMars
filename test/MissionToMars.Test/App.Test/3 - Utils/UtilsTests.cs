
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissionToMars.App.Utils;

namespace MissionToMars.Test.App.Test.Utils
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void UtilsTest_ValidateCommandSetup_RightCommand_ShouldReturnTrue()
        {
            //Arrange
            var setupPlateauCommand = "5 5";
            //Act
            var result = NasaUtils.ValidateCommand(setupPlateauCommand);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UtilsTest_ValidateSendRover_RightCommand_ShouldReturnTrue()
        {
            //Arrange
            var setupPlateauCommand = "1 2 N";
            //Act
            var result = NasaUtils.ValidateCommand(setupPlateauCommand);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UtilsTest_ValidateExplore_RightCommand_ShouldReturnTrue()
        {
            //Arrange
            var setupPlateauCommand = "MMMRLRMRM";
            //Act
            var result = NasaUtils.ValidateCommand(setupPlateauCommand);
            //Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("555")]
        [DataRow("111N")]
        [DataRow("ABDBDB")]
        public void UtilsTest_WrongCommand_ShouldReturnFalse(string command)
        {
           
            //Act
            var result = NasaUtils.ValidateCommand(command);
            //Assert
            Assert.IsFalse(result);
        }
    }
}
