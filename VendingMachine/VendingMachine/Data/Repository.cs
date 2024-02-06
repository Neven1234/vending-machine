using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendingMachine.DTOs;
using VendingMachine.Models;

namespace VendingMachine.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IAuthRepository _authRepository;

        public Repository(AppDbContext dbContext, IAuthRepository authRepository)
        {
           _dbContext = dbContext;
          _authRepository = authRepository;
        }
        public async Task AddProduct(string userId,ProductDTO productDTO)
        {
            Product NewProduct = new Product
            {
                ProductName = productDTO.ProductName,
                AmountAvailable = productDTO.AmountAvailable,
                Cost = productDTO.Cost,
                SellerId = userId
            };
            await _dbContext.products.AddAsync(NewProduct);
        }

        public async Task<object> Buy(string userId, int amountOfProducts, int productId)
        {
            var product= await GetByIdAsync(productId);
            if (product.AmountAvailable < amountOfProducts)
            {
                return await Task.FromResult<object>("out of stock");
            }
                
            var total = product.Cost * amountOfProducts;
            var user = await _authRepository.GetUserByIdAsync(userId);
            if (user.Deposit<total)
            {

                return await Task.FromResult<object>("you need to deposit more money");
            }
            var change = user.Deposit - total;
            user.Deposit = change;
            product.AmountAvailable -= amountOfProducts;
            if (await SaveAll())
            {
                return await Task.FromResult<object>(new
                {
                    Total=total,
                    Change=change,
                    Product=product.ProductName+"X"+amountOfProducts
                });
            }
            return  await Task.FromResult<object>(null);

        }

        public  void Delete<T>(T entity) where T : class
        {
             _dbContext.Remove(entity);
        }

        public async Task<int?> deposit(int amountOfMoney,string userId)
        {
            if (checkDepositAndCost(amountOfMoney))
            {
                return null;
            }
            var user = await _authRepository.GetUserByIdAsync(userId);
            user.Deposit += amountOfMoney;
            await _dbContext.SaveChangesAsync();
            return user.Deposit;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            
            return await _dbContext.products.ToListAsync(); ;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.products.FindAsync(id); ;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync()>0;
        }
        //helper function
        public bool checkDepositAndCost(int amountOfMoney)
        {
            if(amountOfMoney %5==0 && amountOfMoney<=100)
            {
                return true;
            }
            return false;
        }
       
    }
}
