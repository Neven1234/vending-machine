using Microsoft.AspNetCore.Identity;

namespace VendingMachine.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int? Deposit { get; set; }
    }
}
