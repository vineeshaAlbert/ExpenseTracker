using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.Auth
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
