using Common.ResponseObject;
using DtoLayer.PortfolioDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IPortfolioService
    {
        Task<List<PortfolioListDto>> GetAll();
        Task<IResponse<PortfolioCreateDto>> Create(PortfolioCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<PortfolioUpdateDto>> Update(PortfolioUpdateDto dto);
    }
}
