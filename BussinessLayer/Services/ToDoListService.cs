using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.SkillDtos;
using DtoLayer.ToDoListDtos;
using EntityLayer.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateToDoListDto> _createDtoValidator;
        private readonly IValidator<UpdateToDoListDto> _updateDtoValidator;

        public ToDoListService(IUow uow, IMapper mapper, IValidator<CreateToDoListDto> createDtoValidator, IValidator<UpdateToDoListDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<List<ListToDoListDto>> GetAll()
        {

            var data = _mapper.Map<List<ListToDoListDto>>(await _uow.GetRepository<ToDoList>().GetAll());
            return data;
        }

        public async Task<IResponse<CreateToDoListDto>> Create(CreateToDoListDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<ToDoList>().Create(_mapper.Map<ToDoList>(dto));
                await _uow.SaveChanges();
                return new Response<CreateToDoListDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<CreateToDoListDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(validationResult));
            }

        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<ToDoList>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removed = await _uow.GetRepository<ToDoList>().GetByFilter(x => x.Id == id);
            if (removed != null)
            {
                _uow.GetRepository<ToDoList>().Remove(removed);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

        public async Task<IResponse<UpdateToDoListDto>> Update(UpdateToDoListDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<ToDoList>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<ToDoList>().Update(_mapper.Map<ToDoList>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<UpdateToDoListDto>(ResponseType.Success, dto);
                }
                return new Response<UpdateToDoListDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<UpdateToDoListDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(result));
            }

        }
    }
}
