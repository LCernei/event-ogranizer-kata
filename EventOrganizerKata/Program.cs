using System;
using System.Collections.Generic;
using System.IO;

namespace EventOrganizerKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var resourcesPath = Path.Combine(projectPath, "Resources");
            string filePath = Path.Combine(resourcesPath, "data.txt");

            FileReader fileReader = new FileReader(filePath);//Properties.Resources.data

            List<Event> eventList = fileReader.GetEvents();

            EventOrganizer eo = new EventOrganizer(eventList);
            List<string> eventAndOrelappingList = eo.GetEventsAndOverlappingIntervals();

            Console.Write(eventAndOrelappingList.);

        }
    }
}
