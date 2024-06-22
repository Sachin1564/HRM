﻿using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IPortfolioService
    {
        Task<List<PortfolioListVM>> GetAllListAsync();
        Task AddPortfoliotAsync(PortfolioAddVM request);
        Task DeletePortfolioAsync(int id);
        Task<PortfolioUpdateVM> GetPortfolioById(int id);
        Task UpdatePortfolioAsync(PortfolioUpdateVM request);
    }
}
