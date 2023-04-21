using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contactos.Dto;
using Contactos.Entities;

namespace Contactos.Dto.AutoMapper
{
    public class ContactosDTOProfile : Profile
    {
        public ContactosDTOProfile(){
            CreateMap<Contacto, ContactoDTO>().ReverseMap();
            CreateMap<Contacto, SoloContactoDTO>().ReverseMap();
            CreateMap<Telefono, TelefonoDTO>().ReverseMap();
            CreateMap<Telefono, TelefonoContactoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}