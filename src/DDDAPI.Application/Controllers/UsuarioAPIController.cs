using System;
using System.Net;
using System.Threading.Tasks;
using DDDAPI.Domain.Dtos.UsuarioAPI;
using DDDAPI.Domain.Entities;
using DDDAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAPIController : ControllerBase
    {
        private readonly UsuarioAPIService _service;

        public UsuarioAPIController(UsuarioAPIService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                return Ok (await _service.Get());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{CNPJ}", Name="GetByCNPJ")]
        public async Task<ActionResult> GetByCNPJ(string CNPJ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                return Ok (await _service.GetByCNPJ(CNPJ));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioAPIDtoCreate usuarioAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Insert(usuarioAPI);

                if (result == null)
                {
                    return BadRequest();
                }

                return Created(new Uri(Url.Link("GetByCNPJ", new { result.CNPJ})), result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UsuarioAPIDtoUpdate usuarioAPI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Update(usuarioAPI);

                if (result == null)
                {
                    return BadRequest();
                }

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete ("{CNPJ}")]
        public async Task<ActionResult> Delete(string CNPJ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            try
            {
                return Ok (await _service.Delete(CNPJ));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
