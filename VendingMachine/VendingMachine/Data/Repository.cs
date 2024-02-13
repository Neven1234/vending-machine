using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendingMachine.DTOs;
using VendingMachine.Models;
using static VendingMachine.DTOs.DepositEnum;

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
        public async Task AddProduct(string userId,ProductToReturnDTO productDTO)
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

        public async Task<object> BuyAsync(string userId, int amountOfProducts, int productId)
        {
            List<int> Change = new List<int>();
            var product= await GetByIdAsync(productId);
            if (product.AmountAvailable < amountOfProducts)
            {
                return await Task.FromResult<object>("out of stock");
            }
                
            var total = product.Cost * amountOfProducts;
            var user = await _authRepository.GetUserByIdAsync(userId);
            if (user.Deposit<total)
            {

                return await Task.FromResult<object>("you need to Deposit more money");
            }
            var TheChange = (int)(user.Deposit - total);
            user.Deposit = TheChange;
            product.AmountAvailable -= amountOfProducts;
            if (TheChange == 0)
            {
                Change.Add(0);
            }
            var ArrOfChange = await Chnge(TheChange);
            foreach (var item in ArrOfChange)
            {
                if (item == 0)
                { continue; }
                Change.Add(item);
            }
            if (await SaveAllAsync())
            {
                return await Task.FromResult<object>(new
                {
                    Total=total,
                    Change = Change,
                    Product=product.ProductName+" X "+amountOfProducts
                });
            }
            return  await Task.FromResult<object>(null);

        }

        public  void Delete<T>(T entity) where T : class
        {
             _dbContext.Remove(entity);
        }

        public async Task<int?> DepositAsync(int amountOfMoney,string userId)
        {
           
            if(Enum.IsDefined(typeof(DepositTypeEnum), amountOfMoney))
            {
                var user = await _authRepository.GetUserByIdAsync(userId);
                user.Deposit += amountOfMoney;
                return user.Deposit;
            }
            return null;
          
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
        public async Task ResetAsync(string userId)
        {
            var user = await _authRepository.GetUserByIdAsync(userId);
            user.Deposit = 0;

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _dbContext.SaveChangesAsync()>0;
        }
        //helper function
       bool checkDepositAndCost(int amountOfMoney)
        {
            if( amountOfMoney%5==0 && amountOfMoney<=100)
                return true;
            return false;


        }

        public async Task< int[]> Chnge(int money)
        {
            int[] result = new int[5];
            result[0] = money / 100;
            result[0] *= 100;
            var reminder = money % 100;

            result[1] = reminder / 50;
            result[1] *= 50;
            reminder = reminder % 50;

            result[2] = reminder / 20;
            result[2] *= 20;
            reminder = reminder % 20;

            result[3] = reminder / 10;
            result[3] *= 10;
            reminder = reminder % 10;

            result[4] = reminder / 5;
            result[4] *= 5;

            return  result;
        }

       
    }
}
