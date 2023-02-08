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
        public async Task<ActionResult<LoginResponse>> Login(LoginDto loginDto) => await logrepos.Login(loginDto);

    }
}
