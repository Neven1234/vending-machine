using VendingMachine.DTOs;
using VendingMachine.Models;

namespace VendingMachine.Data
{
    public interface IRepository
    {
        Task AddProduct(string userId,ProductToReturnDTO productDTO);
        void Delete<T>(T entity)where T:class;
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<bool> SaveAllAsync();
        Task<int?> DepositAsync(int amountOfMoney, string userId);
        Task<object> BuyAsync(string userId , int amountOfProducts, int productId);
        Task ResetAsync( string userId);


    }
}
