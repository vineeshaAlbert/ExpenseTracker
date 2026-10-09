using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Common.Interfaces
{
    public record TokenResult(string Token, DateTime ExpiresAt);

    public interface IJwtTokenGenerator
    {
        TokenResult Generate(User user);
    }
}
