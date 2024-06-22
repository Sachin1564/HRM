using EntityLayer.WebApplication.ViewModels.CandidateVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface ICandidateService
    {
        Task<List<CandidateListVM>> GetAllListAsync();

        Task AddCandidateAsync(CandidateAddVM request);
        Task DeleteCandidateAsync(int id);
        Task<CandidateUpdateVM> GetCandidateId(int id);
        Task UpdateCandidateAsync(CandidateUpdateVM request);
    }
}
