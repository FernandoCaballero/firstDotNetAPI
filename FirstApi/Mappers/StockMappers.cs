using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Dtos.Stock;
using FirstApi.Models;

namespace FirstApi.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Industry = stockModel.Industry,
                LastDividend = stockModel.LastDividend,
                MarketCap = stockModel.MarketCap,
                Purchase = stockModel.Purchase,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDividend = stockDto.LastDividend,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }

        public static Stock ToStockFromFMP(this FMPStock fmpStock)
        {
            return new Stock
            {
                Symbol = fmpStock.Symbol,
                CompanyName = fmpStock.CompanyName,
                Purchase = (decimal)fmpStock.Price,
                LastDividend = (decimal)fmpStock.LastDiv,
                Industry = fmpStock.Industry,
                MarketCap = fmpStock.MktCap
            };
        }
    }
}