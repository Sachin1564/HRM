﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.HomePageVM;
using EntityLayer.WebApplication.ViewModels.PortfolioVM;
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
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Portfolio> _repository;
        public PortfolioService(IUnitOfWorks unitOfWorks, IMapper mapper, IGenericRepositories<Portfolio> repository)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = repository;
        }


        public async Task<List<PortfolioListVM>> GetAllListAsync()
        {
            var portfolioListVM = await _repository.GetAlltEntityList().ProjectTo<PortfolioListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return portfolioListVM;
        }
        public async Task AddPortfoliotAsync(PortfolioAddVM request)
        {
            var portfolio = _mapper.Map<Portfolio>(request);
            await _repository.AddEntityAsync(portfolio);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task DeletePortfolioAsync(int id)
        {
            var portfolio = await _repository.GetEntityByIdAsync(id);
            _repository.DeletetEntity(portfolio);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task<PortfolioUpdateVM> GetPortfolioById(int id)
        {
            var portfolio = await _repository.Where(x => x.Id == id).ProjectTo<PortfolioUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return portfolio;
        }

        public async Task UpdatePortfolioAsync(PortfolioUpdateVM request)
        {
            var portfolio = _mapper.Map<Portfolio>(request);
            _repository.UpdatetEntity(portfolio);
            await _unitOfWorks.CommitAsnyc();

        }

    }
}
