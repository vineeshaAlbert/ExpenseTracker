using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string hashedPassword, string providedPassword);
    }
}
