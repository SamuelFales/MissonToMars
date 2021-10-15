using System.Text.RegularExpressions;

namespace MissionToMars.App.Utils
{
    public static class NasaUtils
    {

        public static bool ValidateCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return false;
            if (!ValidateCommandExplore(command)
                    && !ValidateCommandRover(command)
                        && !ValidateCommandSetupPlateau(command))
                return false;

            return true;
        }

        private static bool ValidateCommandSetupPlateau(string command)
        {
            var patternPlateu = @"([0-9]{1})(\s)([0-9]{1})";
            var regex = new Regex(patternPlateu);
            if (regex.IsMatch(command))
                return true;
            else
                return false;
        }

        private static bool ValidateCommandRover(string command)
        {
            var patternRover = @"([0-9]{1})(\s)([0-9]{1})(\s)([WSENwsen]{1})";
            var regex = new Regex(patternRover);
            if (regex.IsMatch(command))
                return true;
            else
                return false;
        }

        private static bool ValidateCommandExplore(string command)
        {
            var patternExplore = @"[MLRmlr]{1,}";
            var regex = new Regex(patternExplore);
            if (regex.IsMatch(command))
                return true;
            else
                return false;
        }
    }
}
