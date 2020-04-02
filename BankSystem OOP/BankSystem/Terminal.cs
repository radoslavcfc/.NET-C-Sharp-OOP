using Logging;
using BankSystem.Contracts;
using Enumerations.BankDemo;
namespace BankDemo
{
    public class Terminal: ITerminal
    {
        private ILogger logger;
        private string _terminalId;

        public TerminalState TerminalState { get; set; }

        public Transaction CurrentTransaction { get; set; }

        public OperationType PossibleOperation { get; set; }

        public Terminal(OperationType possibleOperation, string terminalId, ILogger logger)
        {
            this.logger = logger;
            this.TerminalState = TerminalState.Free;
            this.PossibleOperation = possibleOperation;
            this._terminalId = terminalId;
            this.logger = logger;
        }

        public void StartTransaction()
        {
            this.CurrentTransaction.Start();
            this.TerminalState = TerminalState.Busy;
            logger.Info("at terminal :" + this._terminalId + "\n");            
        }

        public void ProcessAndFinnishTransaction()
        {
            this.TerminalState = TerminalState.Free;

            this.logger.Info($"A transaction {this.CurrentTransaction.TransactionId} " +
                                " with type - " + this.PossibleOperation +
                                " has been completed for " + this.CurrentTransaction.Customer.PersonName +   
                                " at terminal " + this._terminalId + '!' + "\n");

            this.CurrentTransaction.Finish();
        }
    }
}