using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.HeaderDtos;
using DtoLayer.SkillDtos;
using EntityLayer.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class HeaderService : IHeaderService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<HeaderUpdateDto> _updateDtoValidator;

        public HeaderService(IMapper mapper, IUow uow, IValidator<HeaderUpdateDto> updateDtoValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<List<HeaderListDto>> GetAll()
        {

            var data = _mapper.Map<List<HeaderListDto>>(await _uow.GetRepository<Header>().GetAll());
            return data;
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Header>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse<HeaderUpdateDto>> Update(HeaderUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Header>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Header>().Update(_mapper.Map<Header>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<HeaderUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<HeaderUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<HeaderUpdateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(result));
            }

        }
    }
}
