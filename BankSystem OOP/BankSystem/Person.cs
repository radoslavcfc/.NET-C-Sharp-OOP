using Logging;
using System;

namespace BankDemo
{
    public class Person
    {
        public string PersonName { get; private set; }

        public Person(string name, ILogger logger)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this.PersonName = name;
            }

            else
            {
                logger.Error("Empty string cannot be used for a name of the person");
                throw new Exception();
            }
        }
    }
}