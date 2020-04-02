using BankDemo;
using Enumerations.BankDemo;

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
