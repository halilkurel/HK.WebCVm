using Common.ResponseObject;
using DtoLayer.TestimonialDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface ITestimonialService
    {
        Task<List<TestimonialListDto>> GetAll();
        Task<IResponse<TestimonialCreateDto>> Create(TestimonialCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<TestimonialUpdateDto>> Update(TestimonialUpdateDto dto);
    }
}
