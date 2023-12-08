using Common.ResponseObject;
using DtoLayer.PortfolioDtos;
using DtoLayer.ServicesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IServicesService
    {
        Task<List<ServicesListDto>> GetAll();
        Task<IResponse<ServiceCreateDto>> Create(ServiceCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<ServiceUpdateDto>> Update(ServiceUpdateDto dto);
    }
}
