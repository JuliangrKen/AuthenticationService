using System;
using System.IO;

namespace AuthenticationService
{
    public class Logger : ILogger
    {
        private readonly string LogDbDir = $"{Environment.CurrentDirectory}\\Logs";

        public Logger()
            => CreateNewDb();

        public void WriteEvent(string message)
        {
            PrintConsoleMessage(message, MessageType.Event);
            SaveLogInData(message, MessageType.Event);
        }

        public void WriteError(string message)
        {
            PrintConsoleMessage(message, MessageType.Error);
            SaveLogInData(message, MessageType.Error);
        }

        private void PrintConsoleMessage(string message, MessageType type)
        {
            Console.ForegroundColor = GetConsoleColorByMessageType(type);
            Console.Write(MessageToLogFormat(message));
            Console.ResetColor();
        }

        private ConsoleColor GetConsoleColorByMessageType(MessageType type)
            => type switch
            {
                MessageType.Event => ConsoleColor.Yellow,
                MessageType.Error => ConsoleColor.Red,
                _ => ConsoleColor.White
            };

        private void CreateNewDb()
        {
            if (Directory.Exists(LogDbDir))
                Directory.Delete(LogDbDir, true);

            Directory.CreateDirectory(LogDbDir);
        }

        private void SaveLogInData(string message, MessageType type)
            => File.AppendAllText($"{LogDbDir}\\{SelectLogFileName(type)}.txt", MessageToLogFormat(message));

        private string SelectLogFileName(MessageType type)
            => type switch
            {
                MessageType.Event => "event",
                MessageType.Error => "error",
                _ => "other"
            };

        private string MessageToLogFormat(string message)
            => $"[{DateTime.Now}] {message}\n";
    }
}
