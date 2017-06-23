using AutoMapper;
using HangMan.Modelo;
using HangMan.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Services.Config
{
    public class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<Word, WordDTO>().ReverseMap();
            });
        }
    }
}
