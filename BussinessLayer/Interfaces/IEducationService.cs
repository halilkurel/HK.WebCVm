using Common.ResponseObject;
using DtoLayer.EducationDtos;
using DtoLayer.SkillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IEducationService
    {
        Task<List<EducationListDto>> GetAll();
        Task<IResponse<EducationCreateDto>> Create(EducationCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<EducationUpdateDto>> Update(EducationUpdateDto dto);
    }
}
