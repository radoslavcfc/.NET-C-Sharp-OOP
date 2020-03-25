using BankDemo;
using System.Collections.Generic;

namespace BankSystem.Contracts
{
    public interface IBank
    {
        string Name { get;}

        List<Office> Offices { get; set; }

        void AddOffice(Office office);

        void RemoveOffice(string name);
    }
}
