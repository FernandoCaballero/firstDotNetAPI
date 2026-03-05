using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Data;
using FirstApi.Interfaces;
using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;

        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser appUser)
        {
            return await _context.Portfolios.Where(u => u.AppUserId == appUser.Id)
            .Select(stock => new Stock
            {
                Id = stock.StockId,
                Symbol = stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDividend = stock.Stock.LastDividend,
                Industry = stock.Stock.Industry,
                MarketCap = stock.Stock.MarketCap
            }).ToListAsync();
        }
    }
}