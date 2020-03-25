using Logging;
using BankSystem.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BankDemo
{
    public class Bank : IBank
    {
        private ILogger logger;
        public string Name { get; internal set; }

        public List<Office> Offices { get; set; }

        public Bank(string name, ILogger logger)
        {
            this.logger = logger;

            this.Offices = new List<Office>();

            if (!string.IsNullOrEmpty(name))
            {
                this.Name = name;
            }

            else
            {
               logger.Error("Empty string cannot be used for a name of the bank");
                throw new System.Exception();
            }
        }

        public void AddOffice(Office branchOffice)
        {
            if (branchOffice == null)
            {
                logger.Error("Invalid office object!");
                throw new System.Exception();
            }

            this.Offices.Add(branchOffice);
            logger.Info($"Welcome to {this.Name} - branch : {branchOffice.OfficeName} \n");
        }

        public void RemoveOffice (string name)
        {
            var office = this.Offices
                .FirstOrDefault(o => o.OfficeName == name);

            if (office == null)
            {
                logger.Info($"Office with name {name} doesn`t exist in the bank {this.Name} !");
                return;
            }
            this.Offices.Remove(office);
            logger.Info($"Office with name {name} has been removed from the list in bank {this.Name} !");
        }
    }
}