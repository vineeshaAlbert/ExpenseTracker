using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.Auth
{
    public class RegisterRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
