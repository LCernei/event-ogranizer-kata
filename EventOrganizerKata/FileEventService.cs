using System;
using System.Collections.Generic;
using System.Text;

namespace EventOrganizerKata
{
    public class FileEventService
    {
        private string FileToRead;

        public FileEventService(string fileName)
        {
            this.FileToRead = fileName;
        }


        public List<Event> GetEvents()
        {
            string[] eventsLines = System.IO.File.ReadAllLines(FileToRead);
            List<Event> eventsList = new List<Event>();

            for (int i = 0; i < eventsLines.Length; i++)
            {
                eventsList.Add(ParseLine(eventsLines[i]));
            }
            return eventsList;
        }

        private Event ParseLine(string eventString)
        {
            string[] arr = eventString.Split(',');

            string name = arr[0];
            DateTime.TryParse(arr[1], out DateTime start);
            DateTime.TryParse(arr[2], out DateTime end);

            return new Event(name, start, end);
        }
    }
}
