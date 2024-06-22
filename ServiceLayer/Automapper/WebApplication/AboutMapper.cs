﻿using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper
{
    public class AboutMapper : Profile
    {
        public AboutMapper()
        {
            CreateMap<About, AboutListForUI>().ReverseMap(); 
            CreateMap<About, AboutListVM>().ReverseMap();
            CreateMap<About, AboutAddVM>().ReverseMap();
            CreateMap<About, AboutUpdateVM>().ReverseMap();
        }
       
    }
}