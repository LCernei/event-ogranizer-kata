using System;
using System.Collections.Generic;
using EventOrganizerKata;
using Xunit;

namespace EventOrganizerKata.Test
{
    public class EventOrganizerKataTest
    {
        [Fact]
        public void Test()
        {
            var eventList = new List<Event>();
            DateTime.TryParse("2009-06-15 16:32:00", out var date1);
            DateTime.TryParse("2009-06-15 17:32:00", out var date2);
            eventList.Add(new Event("A", date1, date2));
            eventList.Add(new Event("B", date1, date2));
            
            var eo = new EventOrganizer(eventList);
            var overlapList = eo.GetEventsAndOverlappingIntervals();
            var actual = "";
            foreach (var item in overlapList)
                actual += item + "\n";
            
            Assert.Equal("A overlapping with B between 2009-06-15 16:32:00 and 2009-06-15 17:32:00\n", actual);
        }
    }
}
