namespace EventHubWebApi.Services.AuthService
{
    public interface IAuthService
    {
        Task<User> Register(User user);
        Task<string> Login(UserDTO userDTO);
        string GetName();
    }
}
