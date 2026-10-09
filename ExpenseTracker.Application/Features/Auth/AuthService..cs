using ExpenseTracker.Application.Common.Interfaces;
using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResponse?> RegisterAsync(RegisterRequest request)
        {
            var email = Normalize(request.Email);

            if (await _userRepository.ExistsByEmailAsync(email))
                return null;

            var user = new User
            {
                Email = email,
                PasswordHash = _passwordHasher.Hash(request.Password)
            };

            await _userRepository.AddAsync(user);

            return new AuthResponse { UserId = user.Id, Email = user.Email };
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(Normalize(request.Email));

            // Same null result for "no such user" and "wrong password" -
            // never tell the caller which one it was.
            if (user is null || !_passwordHasher.Verify(user.PasswordHash, request.Password))
                return null;

            var token = _jwtTokenGenerator.Generate(user);

            return new LoginResponse { Token = token.Token, ExpiresAt = token.ExpiresAt };
        }

        private static string Normalize(string email) => email.Trim().ToLowerInvariant();
    }
}
