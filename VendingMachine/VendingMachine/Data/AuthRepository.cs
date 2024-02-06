using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VendingMachine.Models;

namespace VendingMachine.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthRepository(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager
          , IConfiguration configuration ) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        

        public async Task<string> Login(string username, string password)
        {
            var user=await _userManager.FindByNameAsync( username );
            if(user!=null&& await _userManager.CheckPasswordAsync(user,password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim("name",user.UserName),
                    new Claim("userId",user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                var Roles = await _userManager.GetRolesAsync(user);
                foreach (var role in Roles)
                {
                    authClaims.Add(new Claim("Role", role));
                }
                var jwtToken = getToken(authClaims);
                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                return token;
            }
            return "username or password is wrong";
        }

        public async Task<string> Register(User user)
        {
            var userExist = await GetUserAsync(user.Username);
            if (userExist!=null)
            {
                return "user already exist";
            }

            ApplicationUser NewUser = new()
            {
                UserName=user.Username,
                Email=user.Email,
                Deposit=user.Deposit,
                SecurityStamp=Guid.NewGuid().ToString(),
            };
            if (await _roleManager.RoleExistsAsync(user.Role))
            {
                var result = await _userManager.CreateAsync(NewUser, user.Password);
                if (!result.Succeeded)
                {
                    return result.Errors.First().Description;
                }
               await _userManager.AddToRoleAsync(NewUser,user.Role);
                return "user created successgully";
            }
            else
                return "this role doesn't exist";
            
        }

        public async Task<ApplicationUser> GetUserAsync(string username)
        {
            return await _userManager.FindByNameAsync(username); ;
        }

        //helper function
        private JwtSecurityToken getToken(List<Claim> authClims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: this._configuration["JWT:ValidIssuer"],
                audience: this._configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );
            return token;

        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            try
            {

                return await _userManager.FindByIdAsync(userId);
            }
            catch 
            {
                return null;
            }
            
        }

        public async Task<string> GetRole(ApplicationUser user)
        {
            var Roles = await _userManager.GetRolesAsync(user);
            return Roles[0];
        }
    }
}
