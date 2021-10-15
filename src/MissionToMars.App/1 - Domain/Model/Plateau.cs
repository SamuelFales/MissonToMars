namespace MissionToMars.Domain.Model
{
    public class Plateau
    {
        private static Plateau? plateau;

        public int CoordenateX { get; private set; }
        public int CoordenateY {  get; private set; }
        private Plateau(int xMax, int yMax)
        {
            CoordenateX = xMax;
            CoordenateY = yMax;
        }

        public static Plateau? GetInstance(int xMax, int yMax)
        {
            if (plateau == null)
                plateau = new Plateau(xMax, yMax);

            return plateau;
        }
    }
}
