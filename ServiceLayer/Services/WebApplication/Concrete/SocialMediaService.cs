using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SocialMediaVM;
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
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<SocialMedia> _repository;

        public SocialMediaService(IUnitOfWorks unitOfWorks, IMapper mapper, IGenericRepositories<SocialMedia> repository)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = repository;
        }


        public async Task<List<SocialMediaListVM>> GetAllListAsync()
        {
            var socialMediaListVM = await _repository.GetAlltEntityList().ProjectTo<SocialMediaListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return socialMediaListVM;
        }
        public async Task AddSocialMediatAsync(SocialMediaAddVM request)
        {
            var socialMedia = _mapper.Map<SocialMedia>(request);
            await _repository.AddEntityAsync(socialMedia);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task DeleteSocialMediaAsync(int id)
        {
            var socialMedia = await _repository.GetEntityByIdAsync(id);
            _repository.DeletetEntity(socialMedia);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task<SocialMediaUpdateVM> GetSocialMediaById(int id)
        {
            var socialMedia = await _repository.Where(x => x.Id == id).ProjectTo<SocialMediaUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return socialMedia;
        }

        public async Task UpdateSocialMediaAsync(SocialMediaUpdateVM request)
        {
            var socialMedia = _mapper.Map<SocialMedia>(request);
            _repository.UpdatetEntity(socialMedia);
            await _unitOfWorks.CommitAsnyc();

        }
    }
}
