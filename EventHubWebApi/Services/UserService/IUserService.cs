using Microsoft.AspNetCore.Mvc;

namespace EventHubWebApi.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User?> GetSigneUser(int id);

        Task<User?> UpdateUser(int id, User user);

        Task<User?> DeleteUser(int id);
    }
}
