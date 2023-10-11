using EventHubWebApi.Data;
using EventHubWebApi.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;

namespace EventHubWebApi.Services.UserService
{
    public class UserServes : IUserService
    {
        private readonly AppDbContext _context;

        public UserServes(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetSigneUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null)
                return null;

            return user;
        }


        public async Task<User?> UpdateUser(int id, User userReq)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                return null;

            user.Name = userReq.Name;
            user.Email = userReq.Email;
            user.PasswordHash = userReq.PasswordHash;

            await _context.SaveChangesAsync();
            return userReq;
        }

        public async Task<User?> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                return null;

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}

