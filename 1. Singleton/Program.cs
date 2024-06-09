using System;
using System.Collections.Generic;

public class Logger
{
    private static Logger instance;
    private static readonly object lockObj = new object();
    private List<string> logMessages;

    private Logger()
    {
        logMessages = new List<string>();
    }

    public static Logger Instance
    {
        get
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
    }

    public void LogMessage(string message)
    {
        logMessages.Add(message);
        Console.WriteLine(message);
    }

    public void ShowLog()
    {
        foreach (var message in logMessages)
        {
            Console.WriteLine(message);
        }
    }
}

class Program
{
    static void Main()
    {
        Logger logger = Logger.Instance;
        logger.LogMessage("This is the first log message.");
        logger.LogMessage("This is the second log message.");

        Console.WriteLine("Current log:");
        logger.ShowLog();
    }
}
