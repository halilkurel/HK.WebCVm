using Common.ResponseObject;
using DtoLayer.ContactDtos;
using DtoLayer.FooterDtos;

namespace BussinessLayer.Interfaces
{
    public interface IFooterService
    {
        Task<List<FooterListDto>> GetAll();
        Task<IResponse<FooterUpdateDto>> Update(FooterUpdateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
    }
}
