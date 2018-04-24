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
            logger.LogInfo("Now Parsing");

            if (string.IsNullOrEmpty(line))
            {
                logger.LogFatal("This line is empty");
                return null;
            }

            var cells = line.Split(',');
            if (cells.Length < 2)
            {
                logger.LogError("Invalid string length");
                return null;
            }

            var lon = double.Parse(cells[0]);
            var lat = double.Parse(cells[1]);
            var name = cells[2];
            try
            {
                if (lat > Point.MaxLat || lat < -Point.MaxLat) { logger.LogError("Latitude out of range"); return null; }
                if (lon > Point.MaxLon || lon < -Point.MaxLon) { logger.LogError("Longitude out of range"); return null; }
            }
            catch (Exception e)
            {
                logger.LogError("Something wrong with parsing process");
                Console.WriteLine(e);
                return null;
            }

            return new TacoBell
            {
                Location = new Point {Longitude = lon, Latitude = lat}, 
                Name = name
            };
            
        }
    }
}