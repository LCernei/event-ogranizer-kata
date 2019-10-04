using System;
using System.Collections.Generic;
using EventOrganizerKata;
using FluentAssertions;
using Xunit;

namespace EventOrganizerKata.Test
{
    public class EventTest
    {
        [Fact]
        public void GetOverlap_NotOverlappingEvents_ReturnsNull()
        {
            var date11 = new DateTime(2009, 06, 15, 17, 30, 0);
            var date12 = new DateTime(2009, 06, 15, 18, 30, 0);
            var date21 = new DateTime(2008, 06, 15, 17, 30, 0);
            var date22 = new DateTime(2008, 06, 15, 18, 30, 0);
            var event1 = new Event("A", date11, date12);
            var event2 = new Event("B", date21, date22);

            var actual = event1.GetOverlap(event2);

            actual.Should().BeNull();
        }

        [Fact]
        public void GetOverlap_FullOverlapp_ReturnsOverlap()
        {
            var date11 = new DateTime(2009, 06, 15, 17, 30, 0);
            var date12 = new DateTime(2009, 06, 15, 18, 30, 0);
            var event1 = new Event("A", date11, date12);
            var event2 = new Event("B", date11, date12);
            var expected = new Event("", date11, date12);

            var actual = event1.GetOverlap(event2);

            actual.Should().Equals(expected);
        }

        [Fact]
        public void GetOverlap_StartsBeforeEndsDuring_ReturnsOverlap()
        {
            var date11 = new DateTime(2009, 06, 15, 17, 30, 0);
            var date12 = new DateTime(2009, 06, 15, 19, 30, 0);
            var date21 = new DateTime(2009, 06, 15, 16, 30, 0);
            var date22 = new DateTime(2009, 06, 15, 18, 30, 0);
            var event1 = new Event("A", date11, date12);
            var event2 = new Event("B", date21, date22);
            var expected = new Event("", date11, date22);

            var actual = event1.GetOverlap(event2);

            actual.Should().Equals(expected);
        }

    }
}
