using ApniSavari.Application.DTOs;
using ApniSavari.Application.Interfaces;
using ApniSavari.Infrastructure.Persistence.Context;
using ApniSavari.Infrastructure.Persistence.Context.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApniSavari.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApniSavariDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService
            (
             ApniSavariDbContext context,
             IConfiguration configuration
            )
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already registered.");
            }
            if (await _context.Users.AnyAsync(u => u.PhoneNumber == request.PhoneNumber))
            {
                throw new Exception("Phone number already registered.");
            }
            if (request.Password != request.ConfirmPassword)
            {
                throw new Exception("Password and confirm password must be same");
            }
            var user = new User
            {
                FirstName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Status = "Active",
                IsPhoneVerified = false,
                IsEmailVerified = false,
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = DateTime.UtcNow
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            var userRole = new UserRole
            {
                UserId = user.UserId,
                RoleId = 1,
                AssignedAtUtc = DateTime.UtcNow
            };

            _context.UserRoles.Add(userRole);

            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                UserId = user.UserId,
                FullName = $"{user.FirstName} {user.LastName}".Trim(),
                Email = user.Email,
                Role = "Customer"
            };
        }

        private string GenerateToken(User user, string role)
        {
            var key = _configuration["jwt:Key"]!;
            var issuer = _configuration["jwt:Issuer"];
            var audience = _configuration["jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    double.Parse(_configuration["jwt:ExpiryMinutes"]!)),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if(user == null)
            {
                throw new Exception("Invalid email or password.");
            }


            if (user.Status != "Active")
            {
                throw new Exception("Your account is not active.");
            }

            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                throw new Exception("Password is not configured.");
            }

            var passwordValid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

            if (!passwordValid)
                throw new Exception("Invalid email or password.");

            var userRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == user.UserId);

            if (userRole == null)
                throw new Exception("User role not assigned.");

            var role = await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleId == userRole.RoleId);

            if (role == null || !role.IsActive.GetValueOrDefault())
                throw new Exception("User role is inactive.");

            var roleName = role.RoleName ?? "Customer";

            var token = GenerateToken(user, roleName);

            return new AuthResponseDto
            {
                UserId = user.UserId,
                FullName = $"{user.FirstName} {user.LastName}".Trim(),
                Email = user.Email,
                Role = roleName,
                Token = token
            };
        }
    }
}
