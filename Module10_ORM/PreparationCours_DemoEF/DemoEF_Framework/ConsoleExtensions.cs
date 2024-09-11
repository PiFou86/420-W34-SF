using System.Drawing;

namespace DemoEF_Framework
{
    public static class ConsoleExtensions
    {
        public static void DumpException(Exception exception, bool includeFirsStacktrace = false)
        {
            EntitleMessage("Exception dump", ConsoleColor.Red, ConsoleColor.White);
            ChangeForegroundColorTo(ConsoleColor.Red);
            Exception? currentException = exception;

            while (currentException is not null)
            {
                Console.Error.WriteLine(currentException.Message);
                currentException = currentException.InnerException;
            }

            if (includeFirsStacktrace)
            {
                EntitleMessage(exception.StackTrace);
            }

            ChangeForegroundToPreviousColor();
        }

        private static ConsoleColor _previousForegroundConsoleColor = Console.ForegroundColor;
        private static ConsoleColor _previousBackgroundConsoleColor = Console.BackgroundColor;
        public static void ChangeForegroundColorTo(ConsoleColor color) {
            _previousForegroundConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
        }

        public static void ChangeForegroundToPreviousColor()
        {
            Console.ForegroundColor = _previousForegroundConsoleColor;
        }

        public static void WaitForEnterKey()
        {
            ChangeForegroundColorTo(ConsoleColor.Green);
            Console.Out.WriteLine("Press [enter] to continue");
            Console.In.ReadLine();
            ChangeForegroundToPreviousColor();
        }

        public static void EntitleMessage(string? message, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            message = message ?? "(null)";

            int maxLength = message.Split('\n').Select(x => x.Length).Max();
            maxLength = Math.Min(maxLength, Console.WindowWidth - 4); // border space ... space border
            List<string> lines = new List<string>();
            foreach (string messageLine in message.Split('\n'))
            {
                string line = string.Empty;
                foreach (string word in messageLine.Split(' '))
                {
                    if (line.Length + 1 + word.Length > maxLength)
                    {
                        lines.Add(line);
                        line = word;
                    } 
                    else
                    {
                        line += ((line != string.Empty)?' ':string.Empty) + word;
                    }
                }
                lines.Add(line);
            }

            _previousBackgroundConsoleColor = Console.BackgroundColor;
            _previousForegroundConsoleColor = Console.ForegroundColor;

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;

            Console.Out.WriteLine("┌" + new string('─', maxLength + 2) + "┐");
            lines.ForEach(line => Console.Out.WriteLine($"│ {line.PadRight(maxLength)} │"));
            Console.Out.Write("└" + new string('─', maxLength + 2) + "┘");

            Console.BackgroundColor = _previousBackgroundConsoleColor;
            Console.ForegroundColor = _previousForegroundConsoleColor;
            Console.Out.WriteLine();
        }

    }
}
