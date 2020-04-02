using BankSystem.Contracts;
using Enumerations.BankDemo;
using Logging;
using System.Collections.Generic;
using System.Linq;

namespace BankDemo
{
    public class Office : IOffice
    {
        private ILogger logger;

        public string OfficeName { get; set; }
        
        public IEnumerable<IEnumerable<Terminal>> Terminals { get; private set; }

        public List<Terminal> ListCreditTerminals { get; private set; }

        public List<Terminal> ListCashTerminals { get; private set; }

        public Dictionary<OperationType,Queue<Transaction>> MainQueue { get; private set; }

        public Office(string officeName, ILogger logger) 
        {
            this.logger = logger;

            if (string.IsNullOrEmpty(officeName))
            {
                logger.Error("Empty string cannot be used for a name of the bank");
                throw new System.Exception();
            }

            this.OfficeName = officeName;

            this.MainQueue = new Dictionary<OperationType, Queue<Transaction>>()
            {
                [OperationType.Cash] = new Queue<Transaction>(),
                [OperationType.Credit] = new Queue<Transaction>()                
            };

            this.ListCreditTerminals = new List<Terminal>();
           
            this.ListCashTerminals = new List<Terminal>();
           
            this.Terminals = new List<List<Terminal>> { this.ListCashTerminals, this.ListCreditTerminals };
        }

        public void TransactoinRegister(Transaction newTransaction)
        {
            if (newTransaction.TypeOperation == OperationType.Cash)
            {
                this.MainQueue[OperationType.Cash].Enqueue(newTransaction);
            }

            else if (newTransaction.TypeOperation == OperationType.Credit)
            {
                this.MainQueue[OperationType.Credit].Enqueue(newTransaction);
            }

            newTransaction.OnFinished += NewTransaction_OnFinished;
        }

        public void AddCashTerminal(Terminal cashTerminal)
        {
            this.ListCashTerminals.Add(cashTerminal);
        }

        public void AddCreditTerminal(Terminal creditTerminal)
        {
            this.ListCreditTerminals.Add(creditTerminal);
        }

        public void AddTransactions(Transaction [] listOfTransactions)
        {
            foreach (var transaction in listOfTransactions)
            {
                this.TransactoinRegister(transaction);
            }
        }

        private void NewTransaction_OnFinished()
        {
            if (!(this.Terminals
                    .All(listOfterm => listOfterm
                    .All(terminal => terminal.TerminalState == TerminalState.Free))))
            {
                this.ProcessingTransaction();
            }
            else
            {
                this.Start();
            }
        }

        public void Start()
        {            
            while (this.MainQueue[OperationType.Cash]
                     .Any(tr => tr.TransactionState == TransactionState.Waiting) ||
                   this.MainQueue[OperationType.Credit]
                     .Any(tr => tr.TransactionState == TransactionState.Waiting))
            {
                var currentCashTransaction = this.MainQueue[OperationType.Cash]
                    .FirstOrDefault(tr => tr.TransactionState == TransactionState.Waiting);

                var currentCreditTransaction = this.MainQueue[OperationType.Credit]
                    .FirstOrDefault(tr => tr.TransactionState == TransactionState.Waiting);

                var currentCashTerminal = this.ListCashTerminals
                     .FirstOrDefault(ter => ter.TerminalState == TerminalState.Free);

                var currentCreditTerminal = this.ListCreditTerminals
                    .FirstOrDefault(ter => ter.TerminalState == TerminalState.Free);

                if (currentCashTerminal != null && currentCashTransaction != null)
                {
                    currentCashTerminal.CurrentTransaction = currentCashTransaction;
                    currentCashTerminal.StartTransaction();
                }

                if (currentCreditTerminal != null && currentCreditTransaction != null)
                {
                    currentCreditTerminal.CurrentTransaction = currentCreditTransaction;
                    currentCreditTerminal.StartTransaction();
                }

                else
                {
                    this.ProcessingTransaction();
                    break;
                }
            }
        }

        public void ProcessingTransaction()
        {
            foreach (var listOfTerminals in Terminals)
            {
                foreach (var singleTerminal in listOfTerminals)
                {
                    if (singleTerminal.CurrentTransaction.TransactionState == TransactionState.Processing)

                        singleTerminal.ProcessAndFinnishTransaction();
                }
            }
        }
    }
}