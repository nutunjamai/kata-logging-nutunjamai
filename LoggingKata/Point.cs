using System.Runtime.InteropServices.WindowsRuntime;

namespace LoggingKata
{
    public struct Point
    {
        public static readonly double MaxLon = 180;
        public static readonly double MaxLat = 85.05112878;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        }
}