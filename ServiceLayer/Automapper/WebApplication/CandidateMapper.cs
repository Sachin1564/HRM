using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CandidateVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper
{
    public class CandidateMapper : Profile
    {
        public CandidateMapper()
        {
            CreateMap<Candidate, CandidateListVM>().ReverseMap();
            CreateMap<Candidate, CandidateAddVM>().ReverseMap();
            CreateMap<Candidate, CandidateUpdateVM>().ReverseMap();
        }
    }
}
