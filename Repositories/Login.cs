using CrudDemoApp.Data;
using CrudDemoApp.Dto;
using CrudDemoApp.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrudDemoApp.Repositories
{
    public interface ILogin
    {
        Task<TokenModel> Login(LoginDto loginDto);
    }
    public class LoginRepos :ILogin
    {
        private readonly EmployeeContext _context;

        public LoginRepos(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<TokenModel> Login(LoginDto loginDto)
        {
            try
            {

                var user = await _context.employees.Include(x=>x.Role).FirstOrDefaultAsync(x => x.Email == loginDto.email && x.Password == loginDto.password && x.IsActive && !x.IsDelete) ;
                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Role, user.Role.RoleName),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Helper.SymmetricSeccurityKey));

                    var signature = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(Helper.SymmetricSeccurityKey,
                        claims: claims,
                        signingCredentials: signature,
                        expires: DateTime.UtcNow.AddDays(7));

                    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                    return new TokenModel() { token = jwt };


                }
                else
                {
                    throw new ApplicationException("Data Not Found");
                }



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
