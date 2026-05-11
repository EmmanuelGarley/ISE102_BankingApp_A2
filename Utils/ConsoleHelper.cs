using System;

namespace ISE102_A2_BankingApp.Utils
{
    /// <summary>
    /// ConsoleHelper keeps repeated input and display logic in one place.
    /// This improves maintainability and reduces repeated code in Program.cs.
    /// </summary>
    public static class ConsoleHelper
    {
        public static string ReadRequiredString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                Console.WriteLine("Input cannot be empty. Please try again.\n");
            }
        }

        public static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number) && number > 0)
                {
                    return number;
                }

                Console.WriteLine("Please enter a valid positive whole number.\n");
            }
        }

        /// <summary>
        /// Reads money values safely and prevents the program from crashing
        /// when users type invalid text instead of numbers.
        /// </summary>
        public static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal amount))
                {
                    return amount;
                }

                Console.WriteLine("Only numerical data can be entered. Please try again.\n");
            }
        }

        public static void ShowHeader(string title)
        {
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException)
            {
                // Some IDE debug consoles do not support Console.Clear.
                // The program continues without clearing the screen.
            }
            catch (PlatformNotSupportedException)
            {
                // Handles platforms that do not support screen clearing.
            }

            Console.WriteLine("========================================");
            Console.WriteLine(title);
            Console.WriteLine("========================================\n");
        }

        public static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}