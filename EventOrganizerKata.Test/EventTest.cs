using System;
using System.Collections.Generic;
using EventOrganizerKata;
using Xunit;

namespace EventOrganizerKata.Test
{
    public class EventTest
    {
        [Fact]
        public void GetOverlap_NotOverlappingEvents_ReturnsNull()
        {
            DateTime.TryParse("2009-06-15 16:32:00", out var date11);
            DateTime.TryParse("2009-06-15 17:32:00", out var date12);
            DateTime.TryParse("2008-06-15 16:32:00", out var date21);
            DateTime.TryParse("2008-06-15 17:32:00", out var date22);
            var event1 = new Event("A", date11, date12);
            var event2 = new Event("B", date21, date22);

            var actual = event1.GetOverlap(event2);

            Assert.Null(actual);
        }

        [Fact]
        public void GetOverlap_FullOverlapp_ReturnsOverlap()
        {
            DateTime.TryParse("2009-06-15 16:32:00", out var date11);
            DateTime.TryParse("2009-06-15 17:32:00", out var date12);
            var event1 = new Event("A", date11, date12);
            var event2 = new Event("B", date11, date12);

            var actual = event1.GetOverlap(event2);

            Assert.Equal(date11, actual.StartTime);
            Assert.Equal(date12, actual.EndTime);
        }
    }
}
