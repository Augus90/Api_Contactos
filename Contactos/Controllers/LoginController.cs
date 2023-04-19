using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Contactos.Services;
using Contactos.Entities;
using Contactos.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Contactos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IUsuarioService _usuarioService;
        // Nos permire trabajar con el archivo appseting.json
        public IConfiguration _configuration ;

        public LoginController(IConfiguration configuration, IUsuarioService usuarioService){
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post(UsuarioDTO usuario){
            var usuarioActual = _usuarioService.GetUser(usuario);

            if(usuarioActual == null){
                return BadRequest("");
            }

            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", usuarioActual.Id.ToString()),
                new Claim("UserName", usuarioActual.Usuario1),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            
        }

    }
}