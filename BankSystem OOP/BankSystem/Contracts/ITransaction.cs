using BankDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Contracts
{
    public interface ITransaction
    {
        int TransactionId { get; set; }
        OperationType TypeOperation { get; }

        Person Customer { get; }

        TransactionState TransactionState { get; }

        void Start();
        void Finish();
    }
}
