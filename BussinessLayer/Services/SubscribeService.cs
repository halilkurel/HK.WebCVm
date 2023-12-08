using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.SubscribeDtos;
using EntityLayer.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<SubscribeCreateDto> _createDtoValidator;

        public SubscribeService(IUow uow, IMapper mapper, IValidator<SubscribeCreateDto> createDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<SubscribeCreateDto>> Create(SubscribeCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Subscribe>().Create(_mapper.Map<Subscribe>(dto));
                await _uow.SaveChanges();
                return new Response<SubscribeCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<SubscribeCreateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(validationResult));
            }

        }

        public async Task<List<SubscribeListDto>> GetAll()
        {

            var data = _mapper.Map<List<SubscribeListDto>>(await _uow.GetRepository<Subscribe>().GetAll());
            return data;
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Subscribe>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removed = await _uow.GetRepository<Subscribe>().GetByFilter(x => x.Id == id);
            if (removed != null)
            {
                _uow.GetRepository<Subscribe>().Remove(removed);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

        
    }
}
