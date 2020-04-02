using System;
using BankDemo;
using Enumerations.BankDemo;
using Logging;

namespace StartUpPoint
{
    public static class StartUp
    {
        public static void Configure()
        {
            try
            {
                var sampleOffice = SeedSampleInformation();
                sampleOffice.Start();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// /Static seeding method fills up the collections with sample data
        /// </summary>
        /// <returns>
        /// Completed office is returned with demo information for test purposes
        /// </returns>
        public static Office SeedSampleInformation()
        {
            var consoleLogger = new ConsoleLogger();

            var bank = new Bank("Lloyds", consoleLogger);

            var office = new Office("Hereford", consoleLogger);

            bank.AddOffice(office);

            var tran1 = new Transaction(new Person("John", consoleLogger), OperationType.Cash, consoleLogger);
            var tran2 = new Transaction(new Person("Matt", consoleLogger), OperationType.Credit, consoleLogger);
            var tran3 = new Transaction(new Person("Jack", consoleLogger), OperationType.Cash, consoleLogger);
            var tran4 = new Transaction(new Person("Richard", consoleLogger), OperationType.Credit, consoleLogger);
            var tran5 = new Transaction(new Person("Graham", consoleLogger), OperationType.Cash, consoleLogger);
            var tran6 = new Transaction(new Person("Phil", consoleLogger), OperationType.Credit, consoleLogger);
            var tran7 = new Transaction(new Person("James", consoleLogger), OperationType.Cash, consoleLogger);

            var transactionsToGo = new Transaction[] { tran1, tran2, tran3, tran4, tran5, tran6, tran7 };

            office.AddTransactions(transactionsToGo);


            var firstCreditTerminal = new Terminal(OperationType.Credit, "CR_0001", consoleLogger);
            var secondCreditTerminal = new Terminal(OperationType.Credit, "CR_0002", consoleLogger);

            office.AddCreditTerminal(firstCreditTerminal);
            office.AddCreditTerminal(secondCreditTerminal);

            var firstCashTerminal = new Terminal(OperationType.Cash, "CA_0003", consoleLogger);
            var secondCashTerminal = new Terminal(OperationType.Cash, "CA_0004", consoleLogger);

            office.AddCashTerminal(firstCashTerminal);
            office.AddCashTerminal(secondCashTerminal);

            return office;
        }
    }
}
