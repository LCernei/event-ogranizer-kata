using System;
using System.Collections.Generic;

namespace EventOrganizerKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            FileEventService fileData = new FileEventService(@"C:\Users\lcernei\source\repos\EventOrganizerKata\EventOrganizerKata\data.txt");

            List<Event> events = fileData.GetEvents();

            EventOrganizer eo = new EventOrganizer(events);
            List<string> items = eo.GetEventsAndOverlappingIntervals();

            foreach (string item in items)
                Console.WriteLine(item);

        }
    }
}
