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
            Bank bank = new Bank();
            bool running = true;

            while (running)
            {
                ConsoleHelper.ShowHeader("NSW Bank Application - Assessment 3");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. View Registered Users (Demo/Testing)");
                Console.WriteLine("4. Exit");
                Console.Write("\nChoose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunSignup(bank);
                        break;

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

        static void RunSignup(Bank bank)
        {
            ConsoleHelper.ShowHeader("Sign Up");

            string username = ConsoleHelper.ReadRequiredString("Enter username: ");
            string email = ConsoleHelper.ReadRequiredString("Enter email: ");
            int age = ConsoleHelper.ReadPositiveInt("Enter age: ");
            string phone = ConsoleHelper.ReadRequiredString("Enter phone: ");
            string password = ConsoleHelper.ReadRequiredString("Enter password: ");

            bool success = bank.Signup(username, email, age, phone, password);

            if (success)
            {
                Console.WriteLine("\nValidation Tip: Try logging in with the same username and password.");
            }

            ConsoleHelper.Pause();
        }

        static void RunLogin(Bank bank)
        {
            ConsoleHelper.ShowHeader("Login");

            int remainingAttempts = 3;

            while (remainingAttempts > 0)
            {
                string username = ConsoleHelper.ReadRequiredString("Enter username: ");
                string password = ConsoleHelper.ReadRequiredString("Enter password: ");

                UserAccount? loggedInUser = bank.Login(username, password);

                if (loggedInUser != null)
                {
                    Console.WriteLine("\nLogin successful.");
                    ConsoleHelper.Pause();

                    RunBankingMenu(bank, loggedInUser);
                    return;
                }

                remainingAttempts--;
                Console.WriteLine($"\nInvalid username or password. Attempts remaining: {remainingAttempts}");

                if (remainingAttempts == 0)
                {
                    Console.WriteLine("Too many failed login attempts. Returning to main menu.");
                }
            }

            ConsoleHelper.Pause();
        }

        /// <summary>
        /// Assessment 3 banking menu.
        /// This screen is shown only after the user successfully logs in.
        /// </summary>
        static void RunBankingMenu(Bank bank, UserAccount user)
        {
            bool loggedIn = true;
            int withdrawalCount = 0;
            const int maxWithdrawalsPerSession = 3;

            while (loggedIn)
            {
                ConsoleHelper.ShowHeader($"Banking Menu - Welcome {user.GetUsername()}");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. View Balance");
                Console.WriteLine("4. View Transaction History");
                Console.WriteLine("5. Logout");
                Console.Write("\nChoose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        decimal depositAmount = ConsoleHelper.ReadDecimal("Enter deposit amount: ");
                        bank.Deposit(user, depositAmount);
                        ConsoleHelper.Pause();
                        break;

                    case "2":
                        if (withdrawalCount >= maxWithdrawalsPerSession)
                        {
                            Console.WriteLine("Withdrawal limit reached for this login session.");
                            ConsoleHelper.Pause();
                            break;
                        }

                        decimal withdrawAmount = ConsoleHelper.ReadDecimal("Enter withdrawal amount: ");
                        bool withdrawalSuccessful = bank.Withdraw(user, withdrawAmount);

                        if (withdrawalSuccessful)
                        {
                            withdrawalCount++;
                        }

                        Console.WriteLine($"Withdrawals used this session: {withdrawalCount}/{maxWithdrawalsPerSession}");
                        ConsoleHelper.Pause();
                        break;

                    case "3":
                        bank.ViewBalance(user);
                        ConsoleHelper.Pause();
                        break;

                    case "4":
                        ShowTransactionHistory(user);
                        break;

                    case "5":
                        loggedIn = false;
                        Console.WriteLine("Logged out successfully.");
                        ConsoleHelper.Pause();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, 3, 4, or 5.");
                        ConsoleHelper.Pause();
                        break;
                }
            }
        }

        /// <summary>
        /// Extra Assessment 3 feature:
        /// Displays all account transactions recorded during the session.
        /// </summary>
        static void ShowTransactionHistory(UserAccount user)
        {
            ConsoleHelper.ShowHeader("Transaction History");

            var transactions = user.GetTransactionHistory();

            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions recorded.");
            }
            else
            {
                foreach (string transaction in transactions)
                {
                    Console.WriteLine(transaction);
                }
            }

            ConsoleHelper.Pause();
        }

        static void ShowRegisteredUsers(Bank bank)
        {
            ConsoleHelper.ShowHeader("Registered Users - Demo/Testing");

            var users = bank.GetAllUsers();

            Console.WriteLine($"Total registered users: {users.Count}\n");

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].GetSummary()}");
            }

            ConsoleHelper.Pause();
        }
    }
}