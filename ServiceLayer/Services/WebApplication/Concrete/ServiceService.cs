using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CandidateVM;
using EntityLayer.WebApplication.ViewModels.ServiceVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Service> _Repository;

        public ServiceService(IUnitOfWorks unitOfWorks, IMapper mapper, IGenericRepositories<Service> repository)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _Repository = repository;
        }
        public async Task<List<ServiceListVM>> GetAllListAsync()
        {
            var serviceListVM = await _Repository.GetAlltEntityList().ProjectTo<ServiceListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return serviceListVM;
        }
        public async Task AddServiceAsync(ServiceAddVM request)
        {
            var service = _mapper.Map<Service>(request);
            await _Repository.AddEntityAsync(service);
            await _unitOfWorks.CommitAsnyc();
        }
        public async Task DeleteServiceAsync(int id)
        {
            var service = await _Repository.GetEntityByIdAsync(id);
            _Repository.DeletetEntity(service);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task<ServiceUpdateVM> GetServiceId(int id)
        {
            var service = await _Repository.Where(x => x.Id == id).ProjectTo<ServiceUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return service;
        }
        public async Task UpdateServiceAsync(ServiceUpdateVM request)
        {
            var service = _mapper.Map<Service>(request);
            _Repository.UpdatetEntity(service);
            await _unitOfWorks.CommitAsnyc();

        }

    }
}
