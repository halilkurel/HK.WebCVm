using Common.ResponseObject;
using DtoLayer.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IContactService
    {
        Task<List<ContactListDto>> GetAll();
        Task<IResponse<ContactCreateDto>> Create(ContactCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
    }
}
