using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EventOrganizerKata.Test
{
    class EventDataGenerator : IEnumerable<object[]>
    {
        private static readonly DateTime date1 = new DateTime(2009, 06, 15, 17, 30, 0);
        private static readonly DateTime date2 = new DateTime(2009, 06, 15, 18, 30, 0);
        private static readonly DateTime date3 = new DateTime(2009, 06, 15, 19, 30, 0);
        private static readonly DateTime date4 = new DateTime(2009, 06, 15, 20, 30, 0);

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { new Event("A", date1, date2), new Event("B", date1, date2), new Event("", date1, date2)}, //FullOverlap
            new object[] { new Event("A", date1, date2), new Event("B", date1, date3), new Event("", date1, date2)}, //StartsTheSameTime
            new object[] { new Event("A", date1, date3), new Event("B", date2, date3), new Event("", date2, date4)}, //EndsTheSameTime
            new object[] { new Event("A", date1, date3), new Event("B", date2, date4), new Event("", date2, date3)}, //StartsBeforeAndEndsDuring
            new object[] { new Event("A", date1, date4), new Event("B", date2, date3), new Event("", date2, date3)}, //StartsBeforeAndEndsAfter
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
