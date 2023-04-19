using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Contactos.Services;
using Contactos.Entities;
using Contactos.Dto;

namespace Contactos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TelefonoController : ControllerBase
    {
        private ITelefonoService _telefonoService;

        public TelefonoController(ITelefonoService telefonoService){
            _telefonoService = telefonoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            return Ok(await _telefonoService.GetAll());
        }

        [HttpGet("{telefono}")]
        public async Task<IActionResult> GetTelefono(long telefono){
            var contacto = await _telefonoService.GetTelefono(telefono);
            return Ok(contacto);
        }

        // [HttpPost]
        // public async Task<IActionResult> PostTelefono([FromBody] TelefonoDTO telefono){
        //     var result = await _telefonoService.CreateTelefono(telefono);
        //     if(result > 0){
        //         return StatusCode(201);
        //     }

        //     return StatusCode(400);
        // }

        [HttpPost("{dni}")]
        public async Task<IActionResult> PostTelefonoPorDni(long dni,[FromBody] TelefonoDTO telefono){
            var result = await _telefonoService.CreateByDni(dni,telefono);
            if(result > 0){
                return StatusCode(201);
            }

            return StatusCode(400);
        }

        [HttpDelete("{telefono}")]
        public async Task<ActionResult<TelefonoDTO>> Delete(long telefono){
            var result = await _telefonoService.DeleteTelefono(telefono);

            if(result != null){
                return Ok(result);
            }
            
            return NotFound(null);
        }

    }
}