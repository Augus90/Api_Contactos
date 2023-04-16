using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contactos.Entities;
using Contactos.Context;
using Contactos.Dto;
using AutoMapper;

namespace Contactos.Services
{
    public interface IUsuarioService{
        Usuario GetUser(UsuarioDTO usuario);
        Task<int> Save(UsuarioDTO usuario);

    }
    public class UsuarioService : IUsuarioService
    {
        private ContactosContext _dbContext;
        private IMapper _mapper;

        public UsuarioService(ContactosContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
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
    }
}
