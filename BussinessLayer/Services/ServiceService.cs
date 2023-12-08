using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.ServicesDtos;
using EntityLayer.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class ServiceService : IServicesService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<ServiceCreateDto> _createDtoValidator;
        private readonly IValidator<ServiceUpdateDto> _updateDtoValidator;

        public ServiceService(IUow uow, IMapper mapper, IValidator<ServiceCreateDto> createDtoValidator, IValidator<ServiceUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<ServiceCreateDto>> Create(ServiceCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Service>().Create(_mapper.Map<Service>(dto));
                await _uow.SaveChanges();
                return new Response<ServiceCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<ServiceCreateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(validationResult));
            }

        }

        public async Task<List<ServicesListDto>> GetAll()
        {

            var data = _mapper.Map<List<ServicesListDto>>(await _uow.GetRepository<Service>().GetAll());
            return data;
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Service>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removed = await _uow.GetRepository<Service>().GetByFilter(x => x.Id == id);
            if (removed != null)
            {
                _uow.GetRepository<Service>().Remove(removed);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

        public async Task<IResponse<ServiceUpdateDto>> Update(ServiceUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Service>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Service>().Update(_mapper.Map<Service>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<ServiceUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<ServiceUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<ServiceUpdateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(result));
            }

        }

    }
}
