using System;
using System.Net;
using System.Threading.Tasks;
using DDDAPI.Domain.Dtos.Item;
using DDDAPI.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _service;

        public ItemController(ItemService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route ("{Codigo}", Name="Get")]
        public async Task<ActionResult> Get(uint Codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                return Ok (await _service.Get(Codigo));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        [Route ("completo/")]
        public async Task<ActionResult> GetAllCompleto()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                return Ok (await _service.GetAllCompleto());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route ("completo/{Codigo}")]
        public async Task<ActionResult> GetCompletoByCodigo(uint Codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                return Ok (await _service.GetCompletoByCodigo(Codigo));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ItemDtoCreate item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Post(item);

                if (result == null)
                {
                    return BadRequest();
                }

                return Created(new Uri(Url.Link("Get", new { result.Codigo})), result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ItemDtoUpdate item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var result = await _service.Put(item);

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

        [AllowAnonymous]
        [HttpDelete ("{Id}")]
        public async Task<ActionResult> Delete(uint Codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            try
            {
                return Ok (await _service.Delete(Codigo));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
