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
            var eventList = new List<Event>();
            var date1 = new DateTime(2009, 06, 15, 16, 32, 0);
            var date2 = new DateTime(2009, 06, 15, 16, 32, 0);
            eventList.Add(new Event("A", date1, date2));
            eventList.Add(new Event("B", date1, date2));
            var expected = new List<string> { "A overlapping with B between 2009-06-15 16:32:00 and 2009-06-15 17:32:00"};
            var eo = new EventOrganizer(eventList);

            var actual = eo.GetEventsAndOverlappingIntervals();

            actual.Should().Equals(expected);
        }

        [Fact]
        public void GetEventsAndOverlappingIntervals_EmptyList_ReturnsEmptyList()
        {
            var eventList = new List<Event>();
            
            var expected = new List<string>();
            var eo = new EventOrganizer(eventList);

            var actual = eo.GetEventsAndOverlappingIntervals();

            actual.Should().BeEmpty();
        }

        [Fact]
        public void GetEventsAndOverlappingIntervals_Null_ReturnsNull()
        {
            List<Event> eventList = null;

            var eo = new EventOrganizer(eventList);

            var actual = eo.GetEventsAndOverlappingIntervals();

            actual.Should().BeNull();
        }
    }
}
