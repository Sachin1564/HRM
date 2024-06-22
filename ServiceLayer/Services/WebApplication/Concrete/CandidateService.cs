using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.CandidateVM;
using EntityLayer.WebApplication.ViewModels.CategoryVM;
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
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Candidate> _repository;

        public CandidateService(IUnitOfWorks unitOfWorks, IMapper mapper, IGenericRepositories<Candidate> repository)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<CandidateListVM>> GetAllListAsync()
        {
            var candidateListVM = await _repository.GetAlltEntityList().ProjectTo<CandidateListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return candidateListVM;
        }

        public async Task AddCandidateAsync(CandidateAddVM request)
        {
            var candidate = _mapper.Map<Candidate>(request);
            await _repository.AddEntityAsync(candidate);
            await _unitOfWorks.CommitAsnyc();
        }
        public async Task DeleteCandidateAsync(int id)
        {
            var candidate = await _repository.GetEntityByIdAsync(id);
            _repository.DeletetEntity(candidate);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task<CandidateUpdateVM> GetCandidateId(int id)
        {
            var candidate = await _repository.Where(x => x.Id == id).ProjectTo<CandidateUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return candidate;
        }

        public async Task UpdateCandidateAsync(CandidateUpdateVM request)
        {
            var candidate = _mapper.Map<Candidate>(request);
            _repository.UpdatetEntity(candidate);
            await _unitOfWorks.CommitAsnyc();

        }

    }
}
