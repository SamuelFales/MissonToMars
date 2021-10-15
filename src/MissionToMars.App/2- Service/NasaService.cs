using MissionToMars.App.Utils;
using MissionToMars.Domain;
using MissionToMars.Domain.Model;
using System.Text.RegularExpressions;

namespace MissionToMars.Service
{
    public class NasaService
    {
        public List<Rover> RoversOnMars = new(); 
        public Rover? RoverOnLine { get; private set; }
        public Plateau? PlateauOnMars { get; private set; }

        public bool ProcessCommand(string nasaCommand)
        {

            if (!NasaUtils.ValidateCommand(nasaCommand))
                return false;

            var commandAsArray = nasaCommand.Split(' ');
                
            if (commandAsArray.Any() && commandAsArray.Length == 2)
            {
                var coordinateX = Int16.Parse(commandAsArray[0]);
                var coordinateY = Int16.Parse(commandAsArray[1]);
                SetupPlateau(coordinateX, coordinateY);
            }

            else if (commandAsArray.Any() && commandAsArray.Length == 3)
            {
                var positionX = Int16.Parse(commandAsArray[0]);
                var positionY = Int16.Parse(commandAsArray[1]);
                var orientation = Char.Parse(commandAsArray[2]);
                SendRover(new Position(positionX, positionY, orientation));
            }
            else
            {
                RoverOnLine.Explore(nasaCommand);
                ValidateRoverMovimentOnPlateau(RoverOnLine);
            }

            return true;
        }

        private void SendRover(Position pos) 
        {
            RoverOnLine = new Rover(pos);
            RoversOnMars?.Add(RoverOnLine);
        }

        private void SetupPlateau(int coordinateX, int coordinateY) => PlateauOnMars = Plateau.GetInstance(coordinateX, coordinateY);

        private void ValidateRoverMovimentOnPlateau(Rover rover)
        {
            if ((rover.Position.X > PlateauOnMars?.CoordenateX) || (rover.Position.Y > PlateauOnMars?.CoordenateY))
                rover.Status = "OFF";

            if (rover.Position.X == -1 || rover.Position.Y == -1)
                rover.Status = "OFF";
        }

    }
}
