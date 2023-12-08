using Common.ResponseObject;
using DtoLayer.ToDoListDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IToDoListService
    {
        Task<List<ListToDoListDto>> GetAll();
        Task<IResponse<CreateToDoListDto>> Create(CreateToDoListDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<UpdateToDoListDto>> Update(UpdateToDoListDto dto);
    }
}
