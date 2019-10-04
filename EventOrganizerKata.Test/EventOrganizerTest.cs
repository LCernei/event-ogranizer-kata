using System;
using System.Collections.Generic;
using EventOrganizerKata;
using FluentAssertions;
using Xunit;

namespace EventOrganizerKata.Test
{
    public class EventOrganizerTest
    {
        [Fact]
        public void GetEventsAndOverlappingIntervals_ValidData_ReturnsOverlap()
        {
            var date11 = new DateTime(2009, 06, 15, 17, 30, 0);
            var date12 = new DateTime(2009, 06, 15, 18, 30, 0);
            var event1 = new Event("A", date11, date12);
            var event2 = new Event("B", date11, date12);
            var expected = new List<string> { "A overlapping with B between 2009-06-15 17:30:00 and 2009-06-15 18:30:00"};
            var eo = new EventOrganizer(new List<Event> {event1, event2});
            
            var actual = eo.FindOverlappingIntervals();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetEventsAndOverlappingIntervals_EmptyList_ReturnsEmptyList()
        {
            var eventList = new List<Event>();
            
            var expected = new List<string>();
            var eo = new EventOrganizer(eventList);

            var actual = eo.FindOverlappingIntervals();

            actual.Should().BeEmpty();
        }

        [Fact]
        public void GetEventsAndOverlappingIntervals_Null_ReturnsNull()
        {
            var eo = new EventOrganizer(null);

            var actual = eo.FindOverlappingIntervals();

            actual.Should().BeNull();
        }
    }
}
