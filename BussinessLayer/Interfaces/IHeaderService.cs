using Common.ResponseObject;
using DtoLayer.ContactDtos;
using DtoLayer.FooterDtos;
using DtoLayer.HeaderDtos;
using DtoLayer.SkillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IHeaderService
    {
        Task<List<HeaderListDto>> GetAll();
        Task<IResponse<HeaderUpdateDto>> Update(HeaderUpdateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
    }
}
