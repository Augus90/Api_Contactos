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
        Task<IEnumerable<TelefonoDTO>> GetTelefono(long telefono);

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

        public async Task<IEnumerable<TelefonoDTO>> GetTelefono(long telefono)
        {
            var telefonoEncontrado = await _context.Telefonos
                .Include(t => t.Contactos)
                .Where(t => t.NroTelefono == telefono)
                .ToListAsync();
            var dto = _mapper.Map<IEnumerable<TelefonoDTO>>(telefonoEncontrado);

            return dto;
        }


    }
}