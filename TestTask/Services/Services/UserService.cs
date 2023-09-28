using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Services
{
    public class UserService: IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException();
        }

        public async Task<List<User>> GetUsers() =>
            await _context.Users
            .Where(u => u.Status == UserStatus.Inactive)
            .ToListAsync();

        public async Task<User> GetUser() =>
            await _context.Users
            .OrderByDescending(u => u.Orders.Count())
            .FirstOrDefaultAsync();

    }
}
