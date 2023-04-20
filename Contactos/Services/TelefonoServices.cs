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
        Task<IEnumerable<TelefonoContactoDTO>> GetTelefono(long telefono);
        Task<List<TelefonoDTO>> GetAll();

        // Task<int> CreateTelefono(TelefonoDTO telefono);
        Task<int> CreateByDni(long dni, TelefonoDTO telefono);

        Task<TelefonoDTO> DeleteTelefono(long telefono);
    }

    public class TelefonoServices : ITelefonoService
    {
        private readonly ContactosContext _context;
        private readonly IMapper _mapper;

        public TelefonoServices(ContactosContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        // public async Task<int> CreateTelefono(TelefonoDTO telefono)
        // {
        //     var dto = _mapper.Map<Telefono>(telefono);
        //     _context.Telefonos.Add(dto);
            
        //     return await _context.SaveChangesAsync();
        // }

        public async Task<int> CreateByDni(long dni, TelefonoDTO telefono)
        {
            var dto = _mapper.Map<Telefono>(telefono);
            try{
                var id = _context.Contactos.Where(c => c.NroDocumento == dni).FirstOrDefault().Id;
                dto.ContactosId = id;
            }catch{
                return -1;
            }
        
            _context.Telefonos.Add(dto);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<TelefonoDTO> DeleteTelefono(long telefono)
        {
            var telefonoActual = new Telefono();

            try{
                 telefonoActual = _context.Telefonos.Where(t => t.NroTelefono == telefono).First();
            }catch{
                return null;
            }

            _context.Telefonos.Remove(telefonoActual);
            await _context.SaveChangesAsync();
            return _mapper.Map<TelefonoDTO>(telefonoActual);

        }

        public async Task<List<TelefonoDTO>> GetAll(){
            var listaTelefonos =  await _context.Telefonos.ToListAsync();
            return _mapper.Map<List<TelefonoDTO>>(listaTelefonos);
        }

        public async Task<IEnumerable<TelefonoContactoDTO>> GetTelefono(long telefono)
        {
            var telefonoEncontrado = await _context.Telefonos
                .Include(t => t.Contactos)
                .Where(t => t.NroTelefono == telefono)
                .ToListAsync();
            var dto = _mapper.Map<IEnumerable<TelefonoContactoDTO>>(telefonoEncontrado);

            return dto;
        }


    }
}