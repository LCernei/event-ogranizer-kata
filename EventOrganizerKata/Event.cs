using System;
using System.Collections.Generic;
using System.Text;

namespace EventOrganizerKata
{
    public class Event
    {
        public readonly string Name;
        public readonly DateTime StartTime;
        public readonly DateTime EndTime;

        public Event(string name, DateTime start, DateTime end)
        {
            this.Name = name;
            this.StartTime = start;
            this.EndTime = end;
        }

        private bool IsOverlapping(Event newEvent)
        {
            return this.StartTime < newEvent.EndTime && this.EndTime > newEvent.StartTime;
        }

        public Event GetOverlap(Event newEvent)
        {
            if (!this.IsOverlapping(newEvent))
                return null;
            var overlapStart = new DateTime(Math.Max(this.StartTime.Ticks, newEvent.StartTime.Ticks));
            var overlapEnd = new DateTime(Math.Min(this.EndTime.Ticks, newEvent.EndTime.Ticks));
            
            return new Event("", overlapStart, overlapEnd);
        }
    }
}
