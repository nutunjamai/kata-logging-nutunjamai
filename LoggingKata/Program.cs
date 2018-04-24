using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse);

            ITrackable A = null;
            ITrackable B = null;
            double distance = 0;
            foreach (var locA in locations)
            {
                var origin = new GeoCoordinate
                {
                    Latitude = locA.Location.Latitude,
                    Longitude = locA.Location.Longitude
                };

                foreach (var locB in locations)
                {
                    var destination = new GeoCoordinate
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude
                    };

                    var newDistance = origin.GetDistanceTo(destination);
                    if (newDistance > distance)
                    {
                        A = locA;
                        B = locB;
                        distance = newDistance;
                    }
                }
            }

            Console.WriteLine($"The two TacoBells that are furtherest apart are: {A.Name} and {B.Name}");
            Console.WriteLine($"These two locations are {distance} apart");
            Console.ReadLine();
        }
    }
}

            