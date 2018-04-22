using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        /*[Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }*/

        [Theory]
        [InlineData("-86.889051, 33.556383, Taco Bell Birmingham")]
        public void ShouldParse(string line)
        {
            // Arrange
            var parser = new TacoParser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.NotNull(actual.Location);
            Assert.NotNull(actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1234, 1234")] // Cannot parse arrays of length < 3.
        [InlineData("1234, 1234, Location, Other")] // Cannot parse arrays of Length > 3.
        [InlineData("-190.05, 85.50, Location")] // Longitude out of range.
        [InlineData("170.02, 100.20, Location")] // Latitude out of range.
        public void ShouldFailParse(string line)
        {
            //Arrange
            var parser = new TacoParser();
            ITrackable expected = null;
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(actual, expected);
        }
    }
}
