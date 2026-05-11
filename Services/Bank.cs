using System;
using System.Collections.Generic;
using ISE102_A2_BankingApp.Models;

namespace ISE102_A2_BankingApp.Services
{
    /// <summary>
    /// The Bank class manages signup, login, deposit, withdrawal and balance viewing.
    /// It stores multiple users using a List, extending the Assessment 2 solution.
    /// </summary>
    public class Bank
    {
        private List<UserAccount> _users;

        /// <summary>
        /// Constructor creates the user list and adds the dummy user required for testing.
        /// </summary>
        public Bank()
        {
            _users = new List<UserAccount>();

            _users.Add(new UserAccount(
                "Joe.Doe",
                "joe.doe@example.com",
                25,
                "0400000000",
                "Password123",
                1000
            ));
        }

        public bool Signup(string username, string email, int age, string phone, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Error: All fields must be entered correctly.");
                return false;
            }

            if (age <= 0)
            {
                Console.WriteLine("Error: Age must be a positive number.");
                return false;
            }

            if (UsernameExists(username))
            {
                Console.WriteLine("Error: That username is already registered.");
                return false;
            }

            if (EmailExists(email))
            {
                Console.WriteLine("Error: That email is already registered.");
                return false;
            }

            if (PhoneExists(phone))
            {
                Console.WriteLine("Error: That phone number is already registered.");
                return false;
            }

            UserAccount newUser = new UserAccount(username, email, age, phone, password, 0);
            _users.Add(newUser);

            Console.WriteLine("\nSignup successful.");
            Console.WriteLine("You can now log in using your new credentials.");
            return true;
        }

        public UserAccount? Login(string username, string password)
        {
            foreach (UserAccount user in _users)
            {
                if (user.GetUsername().Equals(username, StringComparison.OrdinalIgnoreCase)
                    && user.VerifyPassword(password))
                {
                    return user;
                }
            }

            return null;
        }

        /// <summary>
        /// Deposit method required by Assessment 3.
        /// It rejects zero or negative amounts before updating the balance.
        /// </summary>
        public bool Deposit(UserAccount user, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit failed: Please enter a positive deposit amount.");
                return false;
            }

            user.IncreaseBalance(amount);
            Console.WriteLine($"Deposit successful. New balance: ${user.GetBalance():F2}");
            return true;
        }

        /// <summary>
        /// Withdraw method required by Assessment 3.
        /// It rejects negative values and prevents the balance from going below zero.
        /// </summary>
        public bool Withdraw(UserAccount user, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal failed: Only positive numerical data can be entered for withdrawal.");
                return false;
            }

            if (amount > user.GetBalance())
            {
                Console.WriteLine("Withdrawal failed: Not sufficient fund available.");
                return false;
            }

            user.DecreaseBalance(amount);
            Console.WriteLine($"Withdrawal successful. New balance: ${user.GetBalance():F2}");
            return true;
        }

        /// <summary>
        /// View balance method required by Assessment 3.
        /// </summary>
        public void ViewBalance(UserAccount user)
        {
            Console.WriteLine($"Current balance: ${user.GetBalance():F2}");
        }

        public bool UsernameExists(string username)
        {
            foreach (UserAccount user in _users)
            {
                if (user.GetUsername().Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public bool EmailExists(string email)
        {
            foreach (UserAccount user in _users)
            {
                if (user.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public bool PhoneExists(string phone)
        {
            foreach (UserAccount user in _users)
            {
                if (user.GetPhone().Equals(phone, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public List<UserAccount> GetAllUsers()
        {
            return _users;
        }
    }
}