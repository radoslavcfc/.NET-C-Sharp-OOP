using BankDemo;
using Enumerations.BankDemo;
using System.Collections.Generic;

namespace BankSystem.Contracts
{
    public interface IOffice
    {
        string OfficeName { get; set; }
        
        IEnumerable<IEnumerable<Terminal>> Terminals { get; }

        List<Terminal> ListCreditTerminals { get; }

        List<Terminal> ListCashTerminals { get; }

        Dictionary<OperationType, Queue<Transaction>> MainQueue { get; }

        void TransactoinRegister(Transaction newTransaction);
        
        void AddCashTerminal(Terminal cashTerminal);
        
        void AddCreditTerminal(Terminal creditTerminal);
        
        void AddTransactions(Transaction[] listOfTransactions);
       
        void Start();
        
        void ProcessingTransaction();
       
    }
}
