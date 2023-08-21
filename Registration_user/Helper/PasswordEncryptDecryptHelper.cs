using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Metrics;
using System.Numerics;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Registration_user.Helper;

public class PasswordEncryptDecryptHelper
{
    public string HashedPassword { get; set; }
    public bool CheckPassword(string plainPassword)
    {
        // You would need to use a proper password hashing library like bcrypt, Argon2, etc.
        // Here's a basic example using .NET's built-in hashing functionality (not recommended for production)
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(plainPassword);
            byte[] hashedBytes = sha256.ComputeHash(inputBytes);
            string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            return hashedPassword == HashedPassword;
        }
    }
}