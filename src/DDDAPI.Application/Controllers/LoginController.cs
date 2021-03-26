using System;
using System.Net;
using System.Threading.Tasks;
using DDDAPI.Domain.Dtos.Login;
using DDDAPI.Domain.Entities;
using DDDAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto usuarioAPI)
        {
            if (!ModelState.IsValid || usuarioAPI == null)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var usuario = await _service.GetToken(usuarioAPI);

                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
