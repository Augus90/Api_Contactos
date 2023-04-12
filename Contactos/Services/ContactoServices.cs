using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contactos.Context;
using Contactos.Entities;
using Contactos.Dto;

namespace Contactos.Services
{
    public interface IContactoService{
        IEnumerable<Contacto> GetAllContactos();
    }

    public class ContactoServices : IContactoService
    {
        private ContactosContext _dbContext;

        public ContactoServices(ContactosContext dbContext){
            _dbContext = dbContext;
        }

        public IEnumerable<Contacto> GetAllContactos(){
            return _dbContext.Contactos.ToList();
        }
    }
}