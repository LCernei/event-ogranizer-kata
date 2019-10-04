using System;
using System.Collections.Generic;
using System.Text;

namespace EventOrganizerKata
{
    public class EventOrganizer
    {
        private readonly List<Event> EventList;
        public EventOrganizer(List<Event> events)
        {
            this.EventList = events;
        }

        public List<string> GetEventsAndOverlappingIntervals()
        {
            if (EventList == null)
                return null;
            var eventsAndIntervalsList = new List<string>();
            for (int i = 0; i < EventList.Count - 1; i++)
            {
                for (int j = i + 1; j < EventList.Count; j++)
                {
                    var overlap = EventList[i].GetOverlap(EventList[j]);
                    if (overlap != null)
                    {
                        var eventsAndIntervalString =
                            $"{EventList[i].Name} overlapping with {EventList[j].Name} between " +
                            $"{overlap.StartTime:yyyy-MM-dd HH:mm:ss} and " +
                            $"{overlap.EndTime:yyyy-MM-dd HH:mm:ss}";

                        eventsAndIntervalsList.Add(eventsAndIntervalString);
                    }
                }
            }
            return eventsAndIntervalsList;
        }
    }
}
