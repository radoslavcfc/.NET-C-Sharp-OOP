namespace Logging
{
    public class Logger : ILogger
    {
        public event LogDelegate OnLog;

        public delegate void LogDelegate(Logger logger, LogLevel logLevel, string message);

        public LogLevel LogLevel { get; set; }

        public string Name { get; private set; }

        public Logger(string name)
        {
            this.Name = name;
        }

        void Log(LogLevel logLevel, string message)
        {
            if (OnLog != null && LogLevel <= logLevel)
            {
                OnLog(this, logLevel, message);
            }
        }

        public void Trace(string message)
        {
            Log(LogLevel.Trace, message);
        }

        public void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        public void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        public void Warn(string message)
        {
            Log(LogLevel.Warn, message);
        }

        public void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        public void Fatal(string message)
        {
            Log(LogLevel.Fatal, message);
        }

        public void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new LogAssertException(message);
            }
        }
    }

    public class LogAssertException : System.Exception
    {
        public LogAssertException(string message) : base(message)
        {

        }
    }
}

