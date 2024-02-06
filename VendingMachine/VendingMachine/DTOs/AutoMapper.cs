using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using VendingMachine.Models;

namespace VendingMachine.DTOs
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductToUpdateDTO, Product>();
            CreateMap<Product, ProductToReturnDTO>();
            CreateMap<ApplicationUser, UserDetails>();

        }
    }
}
