using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Contactos.Services;
using Contactos.Entities;
using Contactos.Dto;

namespace Contactos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactosController : ControllerBase
    {
        private IContactoService _contactoService;

        public ContactosController(IContactoService contactoService){
            _contactoService = contactoService;
        }

        [HttpGet]
        public IActionResult GetAll(){
            return Ok(_contactoService.GetAll());
        }

        [HttpGet("{name}")]
        public IActionResult GetNombre(string name){
            return Ok(_contactoService.GetNames(name));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ContactoDTO contacto){
            var result = await _contactoService.Create(contacto);

            if(result > 0){
                return StatusCode(201);
            }

            return StatusCode(400);
        }

        [HttpDelete("{DNI}")]
        public async Task<IActionResult> Delete(long DNI){
            var result = await _contactoService.Delete(DNI);
            if(result != 0){
                return BadRequest();
            }
            return Ok();
        }
    }
}