using EventHubWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventHubWebApi.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;


        public AuthService(AppDbContext context,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _contextAccessor = httpContextAccessor;
        }
        public async Task<string> Login(UserDTO userDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == userDTO.UserName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(userDTO.Password, user.PasswordHash))
            {
                return null;
            }

            string token = CreateUserToken(user);

            return token;
        }

        private string CreateUserToken(User user)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<User> Register(User user)
        {
            string passwordHash =
                BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            user.PasswordHash = passwordHash;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user; 
        }

        public string GetName()
        {
            var result = string.Empty;
            if (_contextAccessor.HttpContext is not null)
            {
                result = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                var roles = _contextAccessor.HttpContext.User
                    .Claims.Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();
                result += $" role: {string.Join(", ", roles)}";
            }
            return result;
        }
    }
}
