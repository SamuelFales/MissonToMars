using System;

namespace MissionToMars.Domain.Model
{
    public class Rover
    {
        public Rover(Position pos)
        {
            Id = new Guid();
            Position = pos;
            Status = "ON";
        }
        
        public Guid Id { get; private set; }
        
        public Position Position { get; private set; }

        public string Status { get; set; }

        public void Explore(string moviments)
        {
            foreach (var nextMoviment in moviments.ToCharArray()) 
            {
                ChangePosition(nextMoviment);
                ChangeOrientation(nextMoviment);
            }
        }

        private void ChangePosition(char nextMoviment)
        {
           if (nextMoviment == 'M')
                switch (this.Position.Orientation)
                {
                    case 'N':
                        this.Position.Y = this.Position.Y + 1;
                        break;
                    case 'S':
                        this.Position.Y = this.Position.Y - 1;
                        break;
                    case 'W':
                        this.Position.X = this.Position.X - 1;
                        break;
                    case 'E':
                        this.Position.X = this.Position.X + 1;
                        break;
                }
        }

        private void ChangeOrientation(char nextMoviment)
        {
            if (this.Position.Orientation == 'N')
                if (nextMoviment == 'L')
                {
                    this.Position.Orientation = 'W';
                    return;
                }
                else if (nextMoviment == 'R')
                {
                    this.Position.Orientation = 'E';
                    return;
                }

            if (this.Position.Orientation == 'S')
                if (nextMoviment == 'L')
                {
                    this.Position.Orientation = 'E';
                    return;
                }
                else if (nextMoviment == 'R')
                {
                    this.Position.Orientation = 'W';
                    return;
                }

            if (this.Position.Orientation == 'W')
                if (nextMoviment == 'L')
                {
                    this.Position.Orientation = 'S';
                    return;
                }
                else if (nextMoviment == 'R')
                {
                    this.Position.Orientation = 'N';
                    return;
                }

            if (this.Position.Orientation == 'E')
                if (nextMoviment == 'L')
                {
                    this.Position.Orientation = 'N';
                    return;
                }
                else if (nextMoviment == 'R')
                {
                    this.Position.Orientation = 'S';
                    return;
                }
        }

        public string GetPosition()
        {
            if (Status == "OFF")
                return "opss.. wrong moviment";

            return Position.X.ToString() + " " + Position.Y.ToString() + " " + Position.Orientation.ToString(); 
        }
    }
}
