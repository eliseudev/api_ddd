using System;
using System.Net;
using System.Threading.Tasks;
using DDDAPI.Domain.Dtos.UF;
using DDDAPI.Domain.Entities;
using DDDAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UFController : ControllerBase
    {
        private readonly UFService _service;

        public UFController(UFService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{Id}", Name="GetUFById")]
        public async Task<ActionResult> Get(uint Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                return Ok (await _service.Get(Id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
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
                return Ok (await _service.GetAll());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
