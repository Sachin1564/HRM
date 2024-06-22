using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.CategoryVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class AboutService : IAboutService
    {

        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<About> _repository;
        public AboutService(IGenericRepositories<About> repository, IUnitOfWorks unitOfWorks, IMapper mapper)
        {

            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<AboutListVM>> GetAllListAsync()
        {
            var aboutListVM = await _repository.GetAlltEntityList().ProjectTo<AboutListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return aboutListVM;
        }
        public async Task AddAboutAsync(AboutAddVM request)
        {
            var about = _mapper.Map<About>(request);
            await _repository.AddEntityAsync(about);
            await _unitOfWorks.CommitAsnyc();
        }

        //public async Task DeleteAboutAsync(int id)
        //{
        //    var about = await _repository.GetEntityByIdAsync(id);
        //    _repository.DeletetEntity(about);
        //    await _unitOfWorks.CommitAsnyc();
        //}

        //public async Task<AboutUpdateVM> GetAboutById(int id)
        //{
        //    var about = await _repository.Where(x => x.Id == id).ProjectTo<AboutUpdateVM>
        //        (_mapper.ConfigurationProvider).SingleAsync();
        //    return about;
        //}
        public async Task<AboutUpdateVM> GetAboutById(int id)
        {
            var about = await _repository.Where(x => x.Id == id).ProjectTo<AboutUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
           
            return about;
        }

        public async Task UpdateAboutAsync(AboutUpdateVM request)
        {
            var about = _mapper.Map<About>(request);
            _repository.UpdatetEntity(about);
            await _unitOfWorks.CommitAsnyc();

        }
        public async Task DeleteAboutAsync(int id)
        {
            var about = await _repository.GetEntityByIdAsync(id);
            _repository.DeletetEntity(about);
            await _unitOfWorks.CommitAsnyc();
        }


        //UI SIDE METHOD

        public async Task<List<AboutListForUI>> GelAllListForUIAsync()
        {
            var aboutListForUI = await _repository.GetAlltEntityList().ProjectTo<AboutListForUI>
               (_mapper.ConfigurationProvider).ToListAsync();

            return aboutListForUI;
        }
    }
}
