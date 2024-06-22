using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TeamVM;
using EntityLayer.WebApplication.ViewModels.TestmonalVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper
{
    public class TestmonalMapper : Profile
    {

        public TestmonalMapper()
        {
            CreateMap<Testmonal, TestmonalListVM>().ReverseMap();
            CreateMap<Team, TestmonalAddVM>().ReverseMap();
            CreateMap<Team, TestmonalUpdateVM>().ReverseMap();
        }
    }
}
