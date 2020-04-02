namespace Enumerations.BankDemo
{
    public enum OperationType
    {
        None = 0,
        Cash = 1,
        Credit = 2
    }

    public enum TransactionState
    {
        None = 0,
        Waiting = 1,
        Processing = 2,        
        Finished = 3
    }

    public enum TerminalState
    {
        None = 0,
        Free = 1,
        Busy = 2
    }
}
