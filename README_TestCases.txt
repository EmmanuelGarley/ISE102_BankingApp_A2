ISE102 Assessment 2 By Emmanuel Garley & Deeanne Kirby - Test Cases

1. Dummy user login
Input:
Username = Joe.Doe
Password = Password123
Expected:
Login successful and main screen displayed.

2. Successful signup
Input:
Username = Mary.Smith
Email = mary@example.com
Age = 22
Phone = 0412345678
Password = Hello123
Expected:
Signup successful.

3. Login with newly signed-up user
Input:
Username = Mary.Smith
Password = Hello123
Expected:
Login successful.

4. Empty field in signup
Input:
Leave one or more fields blank
Expected:
System prompts user to enter all details correctly.

5. Duplicate username
Input:
Register a second account using an existing username
Expected:
Signup rejected with duplicate username message.

6. Invalid login
Input:
Wrong username/password
Expected:
Error shown and user can retry. After 3 failed attempts, return to main menu.