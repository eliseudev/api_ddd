using System;
using System.Net;
using System.Threading.Tasks;
using DDDAPI.Domain.Dtos.Municipio;
using DDDAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly MunicipioService _service;

        public MunicipioController(MunicipioService service)
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
                return Ok (await _service.GetAll());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{Id}", Name="GetMunicipioById")]
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
        [Route("CompletoID/{IdCompleto}")]
        public async Task<ActionResult> GetCompletoById(uint IdCompleto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.GetCompletoById(IdCompleto);

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
        [Route("CompletoIBGE/{codIBGE}")]
        public async Task<ActionResult> GetCompletoByIBGE(int codIBGE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.GetCompletoByIBGE(codIBGE);

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
        public async Task<ActionResult> Post([FromBody] MunicipioDtoCreate municipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Post(municipio);

                if (result == null)
                {
                    return BadRequest();
                }

                return Created(new Uri(Url.Link("GetMunicipioById", new { result.Id})), result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] MunicipioDtoUpdate municipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Put(municipio);

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
