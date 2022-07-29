﻿using AutoMapper;
using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cuenta, CuentaCreacion>();
            CreateMap<TransaccionActualizacion, Transaccion>().ReverseMap();
        }
    }
}
