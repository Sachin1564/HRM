using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.HomePageVM;
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
    public class HomePageService : IHomePageService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<HomePage> _repository;

        public HomePageService(IUnitOfWorks unitOfWorks, IMapper mapper, IGenericRepositories<HomePage> repository)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<HomePageListVM>> GetAllListAsync()
        {
            var homePageListVM = await _repository.GetAlltEntityList().ProjectTo<HomePageListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return homePageListVM;
        }
        public async Task AddHomePagetAsync(HomePageAddVM request)
        {
            var homePage = _mapper.Map<HomePage>(request);
            await _repository.AddEntityAsync(homePage);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task DeleteHomePageAsync(int id)
        {
            var homePage = await _repository.GetEntityByIdAsync(id);
            _repository.DeletetEntity(homePage);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task<HomePageUpdateVM> GetHomePageById(int id)
        {
            var homePage = await _repository.Where(x => x.Id == id).ProjectTo<HomePageUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return homePage;
        }

        public async Task UpdateHomePageAsync(HomePageUpdateVM request)
        {
            var homePage = _mapper.Map<HomePage>(request);
            _repository.UpdatetEntity(homePage);
            await _unitOfWorks.CommitAsnyc();

        }

        //UI SIDE METHOD
        public async Task<List<HomePageListForUI>> GetAllListForUIAsync()
        {
            var homePageListForUI = await _repository.GetAlltEntityList().ProjectTo<HomePageListForUI>
                (_mapper.ConfigurationProvider).ToListAsync();

            return homePageListForUI;
        }

    }
}
