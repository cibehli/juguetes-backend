using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Juguetes.BL.Models;
using Juguetes.BL.DTOs;

namespace Juguetes.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration mapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Productos, ProductoDTO>(); //GET
               cfg.CreateMap<ProductoDTO, Productos>(); //POST -PUT
           });
        }
    }
}
