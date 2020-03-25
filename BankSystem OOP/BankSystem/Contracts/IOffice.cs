using BankDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
