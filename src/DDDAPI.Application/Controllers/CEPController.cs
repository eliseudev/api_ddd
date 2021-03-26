using System;
using System.Net;
using System.Threading.Tasks;
using DDDAPI.Domain.Dtos.CEP;
using DDDAPI.Domain.Entities;
using DDDAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CEPController : ControllerBase
    {
        private readonly CEPService _service;

        public CEPController(CEPService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{Id}", Name="GetCEPById")]
        public async Task<ActionResult> Get(uint Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Get(Id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok (result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("ByCEP/{CEP}")]
        public async Task<ActionResult> Get(string CEP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Get(CEP);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok (result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CEPDtoCreate CEP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Post(CEP);

                if (result == null)
                {
                    return BadRequest();
                }

                return Created(new Uri(Url.Link("GetCEPById", new {result.Id})), result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CEPDtoUpdate CEP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Put(CEP);

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
        [HttpDelete ("{Id}")]
        public async Task<ActionResult> Delete(uint Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            try
            {
                return Ok (await _service.Delete(Id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
