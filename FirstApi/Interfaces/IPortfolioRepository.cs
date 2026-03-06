using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Models;

namespace FirstApi.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser appUser);
        Task<Portfolio> CreateAsync(Portfolio portfolio);
    }
}