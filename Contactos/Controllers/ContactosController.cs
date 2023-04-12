using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contactos.Services;
using Contactos.Entities;

namespace Contactos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactosController : ControllerBase
    {
        private IContactoService _contactoService;

        public ContactosController(IContactoService contactoService){
            _contactoService = contactoService;
        }

        [HttpGet]
        public IActionResult GetAll(){
            return Ok(_contactoService.GetAllContactos());
        }
    }
}