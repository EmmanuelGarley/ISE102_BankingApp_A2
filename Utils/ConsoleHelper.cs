using System;

namespace ISE102_A2_BankingApp.Utils
{
    /// <summary>
    /// Helper methods keep input handling clean and reusable.
    /// This supports modular design and reduces repetition.
    /// </summary>
    public static class ConsoleHelper
    {
        public static string ReadRequiredString(string prompt) // Parameterized method
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                Console.WriteLine("Input cannot be empty. Please try again.\n"); // Prompt the user to try again
            }
        }

        public static int ReadPositiveInt(string prompt) // Parameterized method
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number) && number > 0)
                {
                    return number; // Return the number if it is a valid positive whole number
                }

                Console.WriteLine("Please enter a valid positive whole number.\n"); // Prompt the user to enter a valid positive whole number
            }
        }

       public static void ShowHeader(string title)
        {
            try 
            {

                // Console.Clear can fail in some IDE debug consoles,
                // so we safely try it and continue if the environment does not support it.
                Console.Clear();
            }
            catch (System.IO.IOException)
            {
                // Ignore the error and continue printing the header.
            }
            catch (PlatformNotSupportedException)
            {
                // Ignore if console clearing is not supported.
            }

            Console.WriteLine("========================================");
            Console.WriteLine(title);
            Console.WriteLine("========================================\n");
        }

        public static void Pause()
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        } // Pause the program and wait for the user to press Enter
    }
}