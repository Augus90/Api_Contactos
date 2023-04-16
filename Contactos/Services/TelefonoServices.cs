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
    public interface ITelefonoService{
        IEnumerable<TelefonoDTO> GetTelefono(long telefono);

        Task<int> CreateTelefono(TelefonoDTO telefono);
    }

    public class TelefonoServices : ITelefonoService
    {
        private readonly ContactosContext _context;
        private readonly IMapper _mapper;

        public TelefonoServices(ContactosContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateTelefono(TelefonoDTO telefono)
        {
            var dto = _mapper.Map<Telefono>(telefono);
            _context.Telefonos.Add(dto);
            
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<TelefonoDTO> GetTelefono(long telefono)
        {
            var telefonoEncontrado = _context.Telefonos.Where(t => t.NroTelefono == telefono).ToList();
            var dto = _mapper.Map<IEnumerable<TelefonoDTO>>(telefonoEncontrado);

            return dto;
        }


    }
}