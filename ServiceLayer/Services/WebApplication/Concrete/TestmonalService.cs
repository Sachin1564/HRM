using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TeamVM;
using EntityLayer.WebApplication.ViewModels.TestmonalVM;
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
    public class TestmonalService : ITestmonalService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Testmonal> _repository;

        public TestmonalService(IUnitOfWorks unitOfWorks, IMapper mapper, IGenericRepositories<Testmonal> repository)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<TestmonalListVM>> GetAllListAsync()
        {
            var testmonalListVM = await _repository.GetAlltEntityList().ProjectTo<TestmonalListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return testmonalListVM;
        }
        public async Task AddTestmonaltAsync(TestmonalAddVM request)
        {
            var testmonal = _mapper.Map<Testmonal>(request);
            await _repository.AddEntityAsync(testmonal);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task DeleteTestmonalAsync(int id)
        {
            var testmonal = await _repository.GetEntityByIdAsync(id);
            _repository.DeletetEntity(testmonal);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task<TestmonalUpdateVM> GetTestmonalById(int id)
        {
            var testmonal = await _repository.Where(x => x.Id == id).ProjectTo<TestmonalUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return testmonal;
        }

        public async Task UpdateTestmonalAsync(TestmonalUpdateVM request)
        {
            var testmonal = _mapper.Map<Testmonal>(request);
            _repository.UpdatetEntity(testmonal);
            await _unitOfWorks.CommitAsnyc();

        }
    }
}
