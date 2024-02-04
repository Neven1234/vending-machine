using VendingMachine.Models;

namespace VendingMachine.Data
{
    public interface IAuthRepository
    {
        Task<string> Register(User user);
        Task<string> Login(string username,string password);
        Task<bool> UserExist(string username);
    }
}
