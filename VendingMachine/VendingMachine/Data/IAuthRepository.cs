using VendingMachine.Models;

namespace VendingMachine.Data
{
    public interface IAuthRepository
    {
        Task<string> Register(User user);
        Task<string> Login(string username,string password);
        Task<ApplicationUser> GetUserAsync(string username);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<string> GetRole(ApplicationUser user);

    }
}
