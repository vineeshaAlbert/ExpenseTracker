using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Infrastructure.Auth
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly PasswordHasher<User> _hasher = new();

        public string Hash(string password) => _hasher.HashPassword(null!, password);

        public bool Verify(string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);
            return result != PasswordVerificationResult.Failed;
        }
    }
}
