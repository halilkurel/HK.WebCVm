using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.EducationDtos;
using EntityLayer.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class EducationService : IEducationService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<EducationCreateDto> _createDtoValidator;
        private readonly IValidator<EducationUpdateDto> _updateDtoValidator;

        public EducationService(IUow uow, IMapper mapper, IValidator<EducationCreateDto> createDtoValidator, IValidator<EducationUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }



        public async Task<List<EducationListDto>> GetAll()
        {

            var data = _mapper.Map<List<EducationListDto>>(await _uow.GetRepository<Education>().GetAll());
            return data;
        }

        public async Task<IResponse<EducationCreateDto>> Create(EducationCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Education>().Create(_mapper.Map<Education>(dto));
                await _uow.SaveChanges();
                return new Response<EducationCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<EducationCreateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(validationResult));
            }

        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Education>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removed = await _uow.GetRepository<Education>().GetByFilter(x => x.Id == id);
            if (removed != null)
            {
                _uow.GetRepository<Education>().Remove(removed);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

        public async Task<IResponse<EducationUpdateDto>> Update(EducationUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Education>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Education>().Update(_mapper.Map<Education>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<EducationUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<EducationUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<EducationUpdateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(result));
            }

        }
    }
}
