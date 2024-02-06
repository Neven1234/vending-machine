using VendingMachine.DTOs;
using VendingMachine.Models;

namespace VendingMachine.Data
{
    public interface IRepository
    {
        Task AddProduct(string userId,ProductDTO productDTO);
        void Delete<T>(T entity)where T:class;
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<bool> SaveAll();
        Task<int?> deposit(int amountOfMoney, string userId);
        Task<object> Buy(string userId , int amountOfProducts, int productId);
        bool checkDepositAndCost(int amountOfMoney);

    }
}
