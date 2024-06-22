﻿using AutoMapper;
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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Category> _repository;

        public CategoryService(IUnitOfWorks unitOfWorks, IMapper mapper, IGenericRepositories<Category> repository)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<CategoryListVM>> GetAllListAsync()
        {
            var categoryListVM = await _repository.GetAlltEntityList().ProjectTo<CategoryListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return categoryListVM;
        }
        public async Task AddCategoryAsync(CategoryAddVM request)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.AddEntityAsync(category);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _repository.GetEntityByIdAsync(id);
            _repository.DeletetEntity(category);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task<CategoryUpdateVM> GetCategoryById(int id)
        {
            var category = await _repository.Where(x => x.Id == id).ProjectTo<CategoryUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return category;
        }

        public async Task UpdateCategoryAsync(CategoryUpdateVM request)
        {
            var category = _mapper.Map<Category>(request);
            _repository.UpdatetEntity(category);
            await _unitOfWorks.CommitAsnyc();

        }



    }
}
