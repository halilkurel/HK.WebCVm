using Common.ResponseObject;
using DtoLayer.SubscribeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface ISubscribeService
    {
        Task<List<SubscribeListDto>> GetAll();
        Task<IResponse<SubscribeCreateDto>> Create(SubscribeCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
    }
}
