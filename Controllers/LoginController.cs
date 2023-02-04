using CrudDemoApp.Dto;
using CrudDemoApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin logrepos;

        public LoginController(ILogin logrepos)
        {
            this.logrepos = logrepos;
        }
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginDto loginDto)
        {
            try
            {
                var responce = new LoginResponse();

                var token = await logrepos.Login(loginDto);
                if(token != null)
                {
                    responce.TokenModel = token;
                    return responce;

                }
                else
                {
                    responce.ErrorMessage = "Invalid Creadentials";
                    return responce;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        
    }
}
