using HackerNewsModernUI.Services;
using System;
using Xunit;

namespace HackerNewsTests
{
    public class HowLongAgoTests
    {
        [Fact]
        public void HowLongAgo_1_DayAgo()
        {
            // Arrange
            IUtilities utils = new Utilities();
            var startDate = DateTime.UtcNow;
            var ts = new TimeSpan(days: 1, hours: 0, minutes: 0, seconds: 0);
            var testDate = startDate - ts;

            // Act
            var result = utils.GetHowLongAgo(testDate);

            // Assert
            Assert.Equal("1 day ago", result);
        }

        [Fact]
        public void HowLongAgo_3_DaysAgo()
        {
            // Arrange
            IUtilities utils = new Utilities();
            var startDate = DateTime.UtcNow;
            var ts = new TimeSpan(days: 3, hours: 0, minutes: 0, seconds: 0);
            var testDate = startDate - ts;

            // Act
            var result = utils.GetHowLongAgo(testDate);

            // Assert
            Assert.Equal("3 days ago", result);
        }

        [Fact]
        public void HowLongAgo_1_HourAgo()
        {
            // Arrange
            IUtilities utils = new Utilities();
            var startDate = DateTime.UtcNow;
            var ts = new TimeSpan(days: 0, hours: 1, minutes: 0, seconds: 0);
            var testDate = startDate - ts;

            // Act
            var result = utils.GetHowLongAgo(testDate);

            // Assert
            Assert.Equal("1 hour ago", result);
        }

        [Fact]
        public void HowLongAgo_3_HoursAgo()
        {
            // Arrange
            IUtilities utils = new Utilities();
            var startDate = DateTime.UtcNow;
            var ts = new TimeSpan(days: 0, hours: 3, minutes: 0, seconds: 0);
            var testDate = startDate - ts;

            // Act
            var result = utils.GetHowLongAgo(testDate);

            // Assert
            Assert.Equal("3 hours ago", result);
        }

        [Fact]
        public void HowLongAgo_1_MinuteAgo()
        {
            // Arrange
            IUtilities utils = new Utilities();
            var startDate = DateTime.UtcNow;
            var ts = new TimeSpan(days: 0, hours: 0, minutes: 1, seconds: 0);
            var testDate = startDate - ts;

            // Act
            var result = utils.GetHowLongAgo(testDate);

            // Assert
            Assert.Equal("1 minute ago", result);
        }

        [Fact]
        public void HowLongAgo_3_MinutesAgo()
        {
            // Arrange
            IUtilities utils = new Utilities();
            var startDate = DateTime.UtcNow;
            var ts = new TimeSpan(days: 0, hours: 0, minutes: 3, seconds: 0);
            var testDate = startDate - ts;

            // Act
            var result = utils.GetHowLongAgo(testDate);

            // Assert
            Assert.Equal("3 minutes ago", result);
        }

        [Fact]
        public void HowLongAgo_FutureDate()
        {
            // Arrange
            IUtilities utils = new Utilities();
            var startDate = DateTime.UtcNow;
            var ts = new TimeSpan(days: 0, hours: 0, minutes: 3, seconds: 0);
            var testDate = startDate + ts;
            // Act
            // Should return an Empty String for future dates
            var result = utils.GetHowLongAgo(testDate);

            // Assert
            Assert.Equal(string.Empty, result);
        }
    }
}
