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
        IEnumerable<ContactoDTO> GetAll();

        IEnumerable<ContactoDTO> GetNames(string nombre);

        Task<int> Create(ContactoDTO contactoDTO);

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

        public async Task<int> Create(ContactoDTO contactoDTO)
        {
            var contacto = _mapper.Map<Contacto>(contactoDTO);
            _dbContext.Contactos.Add(contacto);

            return await _dbContext.SaveChangesAsync();
            
        }

        public async Task<int> Delete(long DNI)
        {
            var contacto = _dbContext.Contactos.Where(c => c.NroDocumento == DNI).FirstOrDefault();

            Console.WriteLine(contacto);
            
            if(contacto != null){
                _dbContext.Remove(contacto);
                return await _dbContext.SaveChangesAsync();
            }

            return -1;
        }

        public IEnumerable<ContactoDTO> GetAll(){
            var contactos = _dbContext.Contactos.ToList();
            var contactosList = _mapper.Map<IEnumerable<ContactoDTO>>(contactos);

            return contactosList;
        }

        public IEnumerable<ContactoDTO> GetNames(string nombre){
            var contactoEncontrado = _dbContext.Contactos.Where(c => c.Nombre == nombre).ToList();
            var contacto = _mapper.Map<IEnumerable<ContactoDTO>>(contactoEncontrado);

            return contacto;
        }

    }
}