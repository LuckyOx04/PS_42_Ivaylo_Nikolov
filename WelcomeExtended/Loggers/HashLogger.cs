using System;
using System.Collections.Concurrent;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers;

public class HashLogger : ILogger
{
    private readonly ConcurrentDictionary<int, string> _logMessages;
    private readonly string _name;
    public HashLogger(string name)
    {
        this._name = name;
        this._logMessages = new ConcurrentDictionary<int, string>();
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId,
    TState state, Exception? exception,
    Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);
        switch(logLevel)
        {
            case LogLevel.Critical:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case LogLevel.Error:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.WriteLine("- LOGGER -");
        var messageToBeLogged = new StringBuilder();
        messageToBeLogged.Append($"[{logLevel}]");
        messageToBeLogged.AppendFormat(" [{0}]", _name);
        Console.WriteLine(messageToBeLogged);
        Console.WriteLine($" {formatter(state, exception)}");
        Console.WriteLine("- LOGGER -");
        Console.ResetColor();
        _logMessages[eventId.Id] = message;
        File.WriteAllLines("my-file.txt", _logMessages.Select(
            x => $"[{x.Key}] => [{x.Value}]"
        ));

        Console.WriteLine("Printing all errors:");
        foreach (var item in _logMessages)
        {
            Console.Write($"{item.Key}. {item.Value}");
        }
        Console.WriteLine();

        Console.WriteLine("Printing current event id item:");
        Console.WriteLine(_logMessages[eventId.Id]);
        
        _logMessages.Remove(eventId.Id, out _);
    }
}
