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

        [HttpGet("{telefono}")]
        public IActionResult GetTelefono(long telefono){
            return Ok(_telefonoService.GetTelefono(telefono));
        }

        [HttpPost]
        public async Task<IActionResult> PostTelefono([FromBody] TelefonoDTO telefono){
            var result = await _telefonoService.CreateTelefono(telefono);
            if(result > 0){
                return StatusCode(201);
            }

            return StatusCode(400);
        }

    }
}