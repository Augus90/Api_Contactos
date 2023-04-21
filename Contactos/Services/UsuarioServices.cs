using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contactos.Entities;
using Contactos.Context;
using Contactos.Dto;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Contactos.Services
{
    public interface IUsuarioService{
        Usuario GetUser(UsuarioDTO usuario);
        Task<int> Save(UsuarioDTO usuario);
        Dictionary<string, string> GenerateToken(Usuario usuarioActual);

    }
    public class UsuarioService : IUsuarioService
    {
        private ContactosContext _dbContext;
        public IConfiguration _configuration ;
        private IMapper _mapper;

        public UsuarioService(ContactosContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }
        public Usuario GetUser(UsuarioDTO usuario){
            return _dbContext.Usuarios.SingleOrDefault( user => user.Usuario1 == usuario.Usuario1 && user.Password == usuario.Password);
        }

        public async Task<int> Save(UsuarioDTO usuario){
            var usuarioDTO = _mapper.Map<Usuario>(usuario);
            _dbContext.Add(usuarioDTO);

            return await _dbContext.SaveChangesAsync();
        }

        public Dictionary<string, string> GenerateToken(Usuario usuarioActual){
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
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: signIn);
            Dictionary<string, string> returnToken = new Dictionary<string, string>()
            {
                {"token", new JwtSecurityTokenHandler().WriteToken(token)}
            };
            return returnToken;
        }
    }
}
