using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Contactos.Services;
using Contactos.Entities;
using Contactos.Dto;

namespace Contactos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpController : ControllerBase
    {
        private IUsuarioService _usuarioService;
        public IConfiguration _configuration;

        public SignUpController(IConfiguration configuration, IUsuarioService usuarioService){
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UsuarioDTO usuario){
            var result = await _usuarioService.Save(usuario);
            
            if(result > 0){
                return StatusCode(201);
            }

            return BadRequest();
        }
    }
}