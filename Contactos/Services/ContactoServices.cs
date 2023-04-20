using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contactos.Context;
using Contactos.Entities;
using Contactos.Dto;
using AutoMapper;

namespace Contactos.Services
{
    public interface IContactoService{
        Task<IEnumerable<ContactoDTO>> GetAll(int userId);

        Task<IEnumerable<ContactoDTO>> GetNames(string nombre);

        Task<int> Create(ContactoDTO contactoDTO, int userId);

        Task<int> Delete(long DNI);
    }

    public class ContactoServices : IContactoService
    {
        private readonly ContactosContext _dbContext;
        private readonly IMapper _mapper;

        public ContactoServices(ContactosContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(ContactoDTO contactoDTO, int userId)
        {
            var contacto = _mapper.Map<Contacto>(contactoDTO);
            contacto.UserId = userId;
            _dbContext.Contactos.Add(contacto);

            return await _dbContext.SaveChangesAsync();
            
        }

        public async Task<int> Delete(long DNI)
        {
            var contacto = _dbContext.Contactos
                .Where(c => c.NroDocumento == DNI)
                .FirstOrDefault();
            
            if(contacto != null){
                _dbContext.Remove(contacto);
                return await _dbContext.SaveChangesAsync();
            }

            return -1;
        }

        public async Task<IEnumerable<ContactoDTO>> GetAll(int userId){
            var contactos = await _dbContext.Contactos
                .Include(x => x.Telefonos)
                .Include(x => x.Usuarios)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            var contactosList = _mapper.Map<IEnumerable<ContactoDTO>>(contactos);

            return contactosList;
        }

        public async Task<IEnumerable<ContactoDTO>> GetNames(string nombre){
            var contactoEncontrado = await _dbContext.Contactos
                .Include(x => x.Telefonos)
                .Where(c => c.Nombre == nombre)
                .ToListAsync();

            var contacto = _mapper.Map<IEnumerable<ContactoDTO>>(contactoEncontrado);

            return contacto;
        }

    }
}