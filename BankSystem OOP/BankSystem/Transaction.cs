using BankSystem;
using BankSystem.Contracts;
using Logging;

namespace BankDemo
{
    public delegate void FinishTransaction();
    public class Transaction : ITransaction
    {
        private ILogger logger;

        private IdGenerator idGenerator;
        public int TransactionId { get; set; }
        public OperationType TypeOperation { get; private set; }

        public Person Customer { get; private set; }

        public TransactionState TransactionState { get; private set; }

        public event FinishTransaction OnFinished;

        public Transaction(Person customer, OperationType transactionType, ILogger logger)
        {
            this.logger = logger;

            this.Customer = customer;

            this.TransactionState = TransactionState.Waiting;

            this.TypeOperation = transactionType;

            this.idGenerator = new IdGenerator();

            this.TransactionId = this.idGenerator.GetNextRandomId();
        }

        public void Start()
        {
            this.TransactionState = TransactionState.Processing;
            this.logger.Info("Transaction with ID : " + this.TransactionId +
                               " from type - " + this.TypeOperation +
                               " has been started from " + this.Customer.PersonName + " ");
        }

        public void Finish()
        {
            this.TransactionState = TransactionState.Finished;

            if (this.OnFinished != null)
            {
                this.OnFinished();
            }
        }
    }
}