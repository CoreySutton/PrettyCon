using System;
using System.Diagnostics;

namespace CoreySutton.PrettyCon
{
    public class PrettyCon
    {
        private Stopwatch _stopwatch;
        private bool _enableStopwatch = false;
        private const ConsoleColor _defaultColor = ConsoleColor.Gray;

        public bool EnableTimestamp;
        public ConsoleColor TimestampColor = ConsoleColor.DarkGray;
        public ConsoleColor StopwatchColor = ConsoleColor.DarkGray;

        public bool EnableStopwatch
        {
            get => _enableStopwatch;
            set
            {
                _enableStopwatch = value;
                if (value)
                {
                    _stopwatch = new Stopwatch();
                    _stopwatch.Start();
                }
                else
                {
                    _stopwatch.Stop();
                }
            }
        }

        public void Debug(string message, ConsoleColor color = _defaultColor)
        {
            Print(message, color, "DEBUG", ConsoleColor.DarkBlue);
        }

        public void Verbose(string message, ConsoleColor color = _defaultColor)
        {
            Print(message, color, "VERBOSE", ConsoleColor.Blue);
        }

        public void Info(string message, ConsoleColor color = _defaultColor)
        {
            Print(message, color, "INFO", ConsoleColor.Cyan);
        }

        public void Warning(string message, ConsoleColor color = _defaultColor)
        {
            Print(message, color, "WARNING", ConsoleColor.Yellow);
        }

        public void Error(string message, ConsoleColor color = _defaultColor)
        {
            Print(message, color, "ERROR", ConsoleColor.Red);
        }

        public void Exception(Exception ex)
        {
            if (ex == null) return;

            Print(ex.Message, _defaultColor, "EXCEPTION", ConsoleColor.DarkRed);

            Exception innerEx = ex.InnerException;
            while (innerEx != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(innerEx.Message);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(innerEx.StackTrace);
            }

            Console.ForegroundColor = _defaultColor;
        }

        public void Break(int length = 80)
        {
            string output = "";
            for (int i = 0; i < length; i++)
            {
                output += "-";
            }

            Console.WriteLine(output);
        }

        public void Status(string message, string status, ConsoleColor color)
        {
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(status)) return;

            string timestampOutput = PrintTimestamp();
            Console.Write(message);
            string stopwatchOutput = PrintStopwatch();
            
            // Calculate status width
            int statusPaddingLength = 2;
            int newLineCharacterLength = 1;
            int statusWidth = status.Length + statusPaddingLength + newLineCharacterLength;

            // Calculate total message length
            int totalMessageLength = message.Length;
            if (!string.IsNullOrEmpty(timestampOutput)) totalMessageLength += timestampOutput.Length;
            if (!string.IsNullOrEmpty(stopwatchOutput)) totalMessageLength += stopwatchOutput.Length;

            // Calculate the status offset
            int offset;
            if (totalMessageLength + statusWidth <= Console.WindowWidth || 
                totalMessageLength > Console.WindowWidth)
            {
                offset = Console.WindowWidth - statusWidth;
            }
            else
            {
                // Force the annoation to be at the end of the next line
                Console.WriteLine();
                offset = Console.WindowWidth - statusWidth;
            }

            Console.ForegroundColor = color;
            Console.CursorLeft = offset;
            Console.WriteLine($"[{status}]");
            Console.ForegroundColor = _defaultColor;
        }

        private void Print(string message, ConsoleColor messageColor, string type, ConsoleColor typeColor)
        {
            if (message == null || string.IsNullOrEmpty(message)) return;

            PrintTimestamp();

            Console.ForegroundColor = typeColor;
            Console.Write($"[{type}] ");

            Console.ForegroundColor = messageColor;
            Console.Write(message);

            PrintStopwatch();

            Console.WriteLine();
        }

        private string PrintTimestamp()
        {
            string timestampOutput = "";
            if (EnableTimestamp)
            {                
                timestampOutput = $"[{DateTime.Now.ToString("HH:mm:ss")}] ";

                Console.ForegroundColor = TimestampColor;
                Console.Write(timestampOutput);
                Console.ForegroundColor = _defaultColor;
            }

            return timestampOutput;
        }

        private string PrintStopwatch()
        {
            string stopwatchOutput = "";
            if (EnableStopwatch)
            {
                stopwatchOutput = $" [{_stopwatch.ElapsedMilliseconds} ms]";

                Console.ForegroundColor = StopwatchColor;
                Console.Write(stopwatchOutput);
                Console.ForegroundColor = _defaultColor;
            }

            return stopwatchOutput;
        }
    }
}
