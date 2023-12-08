using Common.ResponseObject;
using DtoLayer.AboutDtos;
using DtoLayer.HeaderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IAboutService
    {
        Task<List<AboutListDto>> GetAll();
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse<AboutUpdateDto>> Update(AboutUpdateDto dto);
    }
}
