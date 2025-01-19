using Main.Requests.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        public AuthController()
        {
                
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync()
        {
            //var response = await _authService.RegisterUserAsync(request);
            //return HandleResponse(response);

            return Ok();
        }
    }
}
