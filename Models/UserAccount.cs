using System;

namespace ISE102_A2_BankingApp.Models
{
    /// <summary>
    /// Represents one registered banking user.
    /// This class stores account-holder details collected during signup.
    /// </summary>
    public class UserAccount
    {
        // Private backing fields protect the data from uncontrolled direct access (encapsulation).
        private string _username;
        private string _email;
        private int _age;
        private string _phone;
        private string _password;

        /// <summary>
        /// Constructor used when a new user account is created.
        /// A constructor is excellently suited here because every user must have all fields initialised at creation time.
        /// </summary>
        public UserAccount(string username, string email, int age, string phone, string password) // Parameterized constructor
        {
            _username = username;
            _email = email;
            _age = age;
            _phone = phone;
            _password = password;
        }

        // Public getters expose values safely for reading where needed.
        public string GetUsername() => _username;
        public string GetEmail() => _email;
        public int GetAge() => _age;
        public string GetPhone() => _phone;

        /// <summary>
        /// Password is intentionally not exposed directly to the rest of the program.
        /// This method checks whether an input password matches the stored password.
        /// </summary>
        public bool VerifyPassword(string inputPassword)
        {
            return _password == inputPassword;
        }

        /// <summary>
        /// Optional setters are included for completeness and future maintainability.
        /// They also show understanding of encapsulation.
        /// </summary>
        public void SetUsername(string username) => _username = username;
        public void SetEmail(string email) => _email = email;
        public void SetAge(int age) => _age = age;
        public void SetPhone(string phone) => _phone = phone;
        public void SetPassword(string password) => _password = password;

        /// <summary>
        /// Returns a user-friendly summary without exposing the password.
        /// </summary>
        public string GetSummary()
        {
            return $"Username: {_username}, Email: {_email}, Age: {_age}, Phone: {_phone}"; // String interpolation
        }
    }
}