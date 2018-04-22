using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            if (string.IsNullOrEmpty(line)) { logger.LogError("This line is empty"); return null; }

            var cells = line.Split(',');
            if (cells.Length < 3) { logger.LogError("Invalid string length"); return null; }

            var lon = double.Parse(cells[0]);
            var lat = double.Parse(cells[1]);
            var name = cells[2];
        }
    }
}