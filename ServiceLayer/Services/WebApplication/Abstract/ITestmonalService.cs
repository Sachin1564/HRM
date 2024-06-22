using EntityLayer.WebApplication.ViewModels.TestmonalVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface ITestmonalService
    {
        Task<List<TestmonalListVM>> GetAllListAsync();

        Task AddTestmonaltAsync(TestmonalAddVM request);

        Task DeleteTestmonalAsync(int id);

        Task<TestmonalUpdateVM> GetTestmonalById(int id);

        Task UpdateTestmonalAsync(TestmonalUpdateVM request);
    }
}
