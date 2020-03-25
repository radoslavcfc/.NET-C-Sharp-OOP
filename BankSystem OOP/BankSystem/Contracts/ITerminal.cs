using BankDemo;

namespace BankSystem.Contracts
{
    public interface ITerminal
    {
        TerminalState TerminalState { get; set; }

        Transaction CurrentTransaction { get; set; }

        OperationType PossibleOperation { get; set; }

        void StartTransaction();

        void ProcessAndFinnishTransaction();
    }
}
