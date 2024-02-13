using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static VendingMachine.DTOs.DepositEnum;

namespace VendingMachine.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int? Deposit { get; set; }
    }
}
