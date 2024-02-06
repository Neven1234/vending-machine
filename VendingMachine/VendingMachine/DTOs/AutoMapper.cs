using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using VendingMachine.Models;

namespace VendingMachine.DTOs
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ApplicationUser, UserDetails>();

        }
    }
}
