using System;
using System.Collections.Generic;

namespace BankSystem
{
    public class IdGenerator
    {
        private const int _defaultId = 1111110;

        private static List<int> IdRecord = new List<int> { _defaultId };
        public int GetNextRandomId()
        {
            var rand = new Random();
            var newId = rand.Next(_defaultId, 9999999);

            while (IdRecord.Contains(newId))
            {
                newId = rand.Next(_defaultId, 9999999);
            }

            IdRecord.Add(newId);

            return newId;
        }
    }
}
