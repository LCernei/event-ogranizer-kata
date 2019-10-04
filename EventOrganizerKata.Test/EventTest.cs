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
            var date21 = new DateTime(2009, 06, 15, 19, 30, 0);
            var date22 = new DateTime(2009, 06, 15, 20, 30, 0);
            var event1 = new Event("A", date11, date12);
            var event2 = new Event("B", date21, date22);

            var actual = event1.GetOverlap(event2);

            actual.Should().BeNull();
        }

        [Theory]
        [ClassData(typeof(EventDataGenerator))]
        public void GetOverlap_OverlappingEvents_ReturnsOverlap(Event event1, Event event2, Event expected)
        {
            var actual = event1.GetOverlap(event2);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetOverlap_OneEndsOtherStarts_ReturnsNull()
        {
            var date11 = new DateTime(2009, 06, 15, 17, 30, 0);
            var date12 = new DateTime(2009, 06, 15, 19, 30, 0);
            var date22 = new DateTime(2009, 06, 15, 18, 30, 0);
            var event1 = new Event("A", date11, date12);
            var event2 = new Event("B", date12, date22);
            var expected = new Event("", date11, date22);

            var actual = event1.GetOverlap(event2);

            actual.Should().BeNull();
        }

        [Fact]
        public void GetOverlap_StartsAndEndsTheSameTime_ReturnsNull()
        {
            var date11 = new DateTime(2009, 06, 15, 17, 30, 0);
            var event1 = new Event("A", date11, date11);
            var event2 = new Event("B", date11, date11);

            var actual = event1.GetOverlap(event2);

            actual.Should().BeNull();
        }
    }
}
