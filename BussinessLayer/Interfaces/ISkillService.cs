using Common.ResponseObject;
using DtoLayer.SkillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface ISkillService
    {
        Task<List<SkillListDto>> GetAll();
        Task<IResponse<SkillCreateDto>> Create(SkillCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<SkillUpdateDto>> Update(SkillUpdateDto dto);
    }
}
