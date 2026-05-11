using System;
using System.Collections.Generic;

namespace ISE102_A2_BankingApp.Models
{
    /// <summary>
    /// Represents one registered banking user.
    /// This class stores the user's personal details, login credentials,
    /// account balance and transaction history.
    /// </summary>
    public class UserAccount
    {
        // Private fields support encapsulation by protecting data from uncontrolled access.
        private string _username;
        private string _email;
        private int _age;
        private string _phone;
        private string _password;
        private decimal _balance;

        // Transaction history is an Assessment 3 extra feature.
        private List<string> _transactionHistory;

        /// <summary>
        /// Constructor initialises a complete user account when signup occurs.
        /// A starting balance is included so the deposit/withdraw features can operate.
        /// </summary>
        public UserAccount(string username, string email, int age, string phone, string password, decimal openingBalance = 0)
        {
            _username = username;
            _email = email;
            _age = age;
            _phone = phone;
            _password = password;
            _balance = openingBalance;
            _transactionHistory = new List<string>();

            _transactionHistory.Add($"Account created with opening balance: ${_balance:F2}");
        }

        public string GetUsername() => _username;
        public string GetEmail() => _email;
        public int GetAge() => _age;
        public string GetPhone() => _phone;
        public decimal GetBalance() => _balance;

        /// <summary>
        /// Password is checked through a method instead of exposing it directly.
        /// This improves security and demonstrates encapsulation.
        /// </summary>
        public bool VerifyPassword(string inputPassword)
        {
            return _password == inputPassword;
        }

        /// <summary>
        /// Adds money to the user's account after validation is completed by the Bank class.
        /// </summary>
        public void IncreaseBalance(decimal amount)
        {
            _balance += amount;
            _transactionHistory.Add($"Deposit: +${amount:F2} | New Balance: ${_balance:F2}");
        }

        /// <summary>
        /// Deducts money from the user's account after validation is completed by the Bank class.
        /// </summary>
        public void DecreaseBalance(decimal amount)
        {
            _balance -= amount;
            _transactionHistory.Add($"Withdrawal: -${amount:F2} | New Balance: ${_balance:F2}");
        }

        /// <summary>
        /// Returns transaction history without allowing outside code to directly edit the list.
        /// </summary>
        public List<string> GetTransactionHistory()
        {
            return new List<string>(_transactionHistory);
        }

        public void SetUsername(string username) => _username = username;
        public void SetEmail(string email) => _email = email;
        public void SetAge(int age) => _age = age;
        public void SetPhone(string phone) => _phone = phone;
        public void SetPassword(string password) => _password = password;

        public string GetSummary()
        {
            return $"Username: {_username}, Email: {_email}, Age: {_age}, Phone: {_phone}, Balance: ${_balance:F2}";
        }
    }
}