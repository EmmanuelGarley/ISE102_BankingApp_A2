using System;
using System.Collections.Generic;
using ISE102_A2_BankingApp.Models;

namespace ISE102_A2_BankingApp.Services
{
    /// <summary>
    /// This Bank class manages login and signup.
    /// It stores multiple users in a List, which is the advanced method mentioned in the task 2 requirements.
    /// </summary>
    public class Bank
    {
        // Private list keeps all registered users in memory during program execution.
        private List<UserAccount> _users;

        /// <summary>
        /// Constructor sets up the bank and seeds a verified dummy user for login testing,
        /// as suggested in the case study.
        /// </summary>
        public Bank()
        {
            _users = new List<UserAccount>();

            // Dummy user recommended by the brief for login attempts.
            _users.Add(new UserAccount(
                "Joe.Doe",
                "joe.doe@example.com",
                25,
                "0400000000",
                "Password123"
            ));
        }

        /// <summary>
        /// Advanced signup method:
        /// Stores more than one registered user in a List<UserAccount>.
        /// Returns true if signup succeeds, false otherwise.
        /// </summary>
        public bool Signup(string username, string email, int age, string phone, string password) // Parameterized method
        {
            // Reject empty/blank values.
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Error: All fields must be entered correctly.");
                return false; // Return false if the fields are empty/blank
            }

            // Extra validation to improve reliability and user experience.
            if (age <= 0)
            {
                Console.WriteLine("Error: Age must be a positive number."); 
                return false; // Return false if the age is not a positive number
            }

            if (UsernameExists(username))
            {
                Console.WriteLine("Error: That username is already registered.");
                return false; // Return false if the username is already registered
            }

            if (EmailExists(email))
            {
                Console.WriteLine("Error: That email is already registered.");
                return false; // Return false if the email is already registered
            }

            if (PhoneExists(phone))
            {
                Console.WriteLine("Error: That phone number is already registered.");
                return false; // Return false if the phone number is already registered
            }

            // If all validation passes, create and store the new user.
            UserAccount newUser = new UserAccount(username, email, age, phone, password);
            _users.Add(newUser);

            Console.WriteLine("\nSignup successful.");
            Console.WriteLine("You can now log in using your new credentials.");
            return true;
        }

        /// <summary>
        /// Login method required by the brief.
        /// It checks entered username and password against registered users.
        /// If successful, it returns the matching UserAccount object.
        /// </summary>
        public UserAccount? Login(string username, string password)
        {
            foreach (UserAccount user in _users)
            {
                if (user.GetUsername().Equals(username, StringComparison.OrdinalIgnoreCase)
                    && user.VerifyPassword(password))
                {
                    return user; // Return the user if the username and password match
                }
            }

            return null; // Return null if the username and password do not match
        }

        /// <summary>
        /// Checks whether a username already exists.
        /// </summary>
        public bool UsernameExists(string username)
        {
            foreach (UserAccount user in _users)
            {
                if (user.GetUsername().Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Return true if the username already exists
                }
            }

            return false; // Return false if the username does not exist
        }

        /// <summary>
        /// Checks whether an email already exists.
        /// </summary>
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

        /// <summary>
        /// Checks whether a phone number already exists.
        /// </summary>
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

        /// <summary>
        /// Returns all users for debug/demo/testing if needed.
        /// This will be used for screenshots during the assessment validation.
        /// </summary>
        public List<UserAccount> GetAllUsers()
        {
            return _users;
        }
    }
}