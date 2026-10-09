using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.Auth
{
    public interface IAuthService
    {
        /// <returns>null if the email is already registered.</returns>
        Task<AuthResponse?> RegisterAsync(RegisterRequest request);

        /// <returns>null if credentials are invalid.</returns>
        Task<LoginResponse?> LoginAsync(LoginRequest request);
    }
}
