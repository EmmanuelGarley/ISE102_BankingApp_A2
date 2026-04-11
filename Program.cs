using System;
using ISE102_A2_BankingApp.Models;
using ISE102_A2_BankingApp.Services;
using ISE102_A2_BankingApp.Utils;

namespace ISE102_A2_BankingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create one Bank object to manage all login and signup operations.
            Bank bank = new Bank();

            bool running = true;

            while (running)
            {
                ConsoleHelper.ShowHeader("NSW Bank Application - Assessment 2 By Emmanuel Garley & Deeanne Kirby");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. View Registered Users (Demo/Testing)");
                Console.WriteLine("4. Exit");
                Console.Write("\nChoose an option: ");
                string? choice = Console.ReadLine(); // Read the user's choice

                switch (choice) // Switch statement to handle the user's choice
                {
                    case "1":
                        RunSignup(bank);
                        break; // Break out of the switch statement

                    case "2":
                        RunLogin(bank);
                        break;

                    case "3":
                        ShowRegisteredUsers(bank);
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("\nThank you for using the NSW Bank Application.");
                        break;

                    default:
                        Console.WriteLine("\nInvalid menu choice. Please select 1, 2, 3, or 4.");
                        ConsoleHelper.Pause();
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the signup workflow.
        /// The implementation requires Username, Email, Age, Phone, and Password.
        /// </summary>
        static void RunSignup(Bank bank)
        {
            ConsoleHelper.ShowHeader("Sign Up"); // Show the sign up header

            string username = ConsoleHelper.ReadRequiredString("Enter username: "); // Read the username
            string email = ConsoleHelper.ReadRequiredString("Enter email: "); // Read the email
            int age = ConsoleHelper.ReadPositiveInt("Enter age: "); // Read the age
            string phone = ConsoleHelper.ReadRequiredString("Enter phone: "); // Read the phone
            string password = ConsoleHelper.ReadRequiredString("Enter password: "); // Read the password

            bool success = bank.Signup(username, email, age, phone, password); // Sign up the user

            if (success)
            {
                Console.WriteLine("\nValidation Tip: Try logging in with the same username and password."); // Prompt the user to try logging in with the same username and password
            }

            ConsoleHelper.Pause();
        }

        /// <summary>
        /// Handles the login workflow.
        /// A 3-attempt limit is implemented for better security and user experience.
        /// </summary>
        static void RunLogin(Bank bank)
        {
            ConsoleHelper.ShowHeader("Login"); // Show the login header

            int remainingAttempts = 3; // Set the remaining attempts to 3

            while (remainingAttempts > 0)
            {
                string username = ConsoleHelper.ReadRequiredString("Enter username: "); // Read the username
                string password = ConsoleHelper.ReadRequiredString("Enter password: "); // Read the password

                UserAccount? loggedInUser = bank.Login(username, password); // Login the user

                if (loggedInUser != null)
                {
                    Console.WriteLine("\nLogin successful.");
                    ShowMainScreen(loggedInUser); // Show the main screen
                    ConsoleHelper.Pause();
                    return;
                }

                remainingAttempts--; // Decrement the remaining attempts
                Console.WriteLine($"\nInvalid username or password. Attempts remaining: {remainingAttempts}"); // Prompt the user to try again

                if (remainingAttempts == 0)
                {
                    Console.WriteLine("Too many failed login attempts. Returning to main menu."); // Prompt the user to try again
                }
            }

            ConsoleHelper.Pause();
        }

        /// <summary>
        /// Simulates the 'main screen' mentioned in the brief after successful login.
        /// </summary>
        static void ShowMainScreen(UserAccount user)
        {
            Console.WriteLine("\n========== Main Screen =========="); // Show the main screen header
            Console.WriteLine($"Welcome, {user.GetUsername()}."); // Welcome the user
            Console.WriteLine("You have successfully accessed the banking system."); // Prompt the user to have successfully accessed the banking system
            Console.WriteLine("=================================");
        }

        /// <summary>
        /// Demo/testing screen to help produce evidence and screenshots.
        /// This is an extra feature that also supports validation and demonstration.
        /// </summary>
        static void ShowRegisteredUsers(Bank bank)
        {
            ConsoleHelper.ShowHeader("Registered Users - Demo/Testing"); // Show the registered users header

            var users = bank.GetAllUsers(); // Get all the users

            if (users.Count == 0)
            {
                Console.WriteLine("No registered users found."); // Prompt the user to no registered users found
            }
            else
            {
                Console.WriteLine($"Total registered users: {users.Count}\n"); // Show the total number of registered users

                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {users[i].GetSummary()}"); // Show the summary of the user
                }
            }

            ConsoleHelper.Pause();
        } // Pause the program and wait for the user to press Enter
    }
}