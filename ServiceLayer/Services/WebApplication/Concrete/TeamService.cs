using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using EntityLayer.WebApplication.ViewModels.TeamVM;
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
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Team> _repository;

        public TeamService(IUnitOfWorks unitOfWorks, IMapper mapper, IGenericRepositories<Team> repository)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<TeamListVM>> GetAllListAsync()
        {
            var teamListVM = await _repository.GetAlltEntityList().ProjectTo<TeamListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return teamListVM;
        }
        public async Task AddTeamtAsync(TeamAddVM request)
        {
            var team = _mapper.Map<Team>(request);
            await _repository.AddEntityAsync(team);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task DeleteTeamAsync(int id)
        {
            var team = await _repository.GetEntityByIdAsync(id);
            _repository.DeletetEntity(team);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task<TeamUpdateVM> GetTeamById(int id)
        {
            var team = await _repository.Where(x => x.Id == id).ProjectTo<TeamUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return team;
        }

        public async Task UpdateTeamAsync(TeamUpdateVM request)
        {
            var team = _mapper.Map<Team>(request);
            _repository.UpdatetEntity(team);
            await _unitOfWorks.CommitAsnyc();

        }
    }
}
