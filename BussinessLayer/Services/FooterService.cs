using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.ContactDtos;
using DtoLayer.FooterDtos;
using DtoLayer.HeaderDtos;
using DtoLayer.PortfolioDtos;
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
    public class FooterService : IFooterService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<FooterUpdateDto> _updateDtoValidator;

        public FooterService(IMapper mapper, IUow uow, IValidator<FooterUpdateDto> updateDtoValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<List<FooterListDto>>GetAll()
        {

            var data = _mapper.Map<List<FooterListDto>>(await _uow.GetRepository<Footer>().GetAll());
            return data;
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Footer>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse<FooterUpdateDto>> Update(FooterUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Footer>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Footer>().Update(_mapper.Map<Footer>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<FooterUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<FooterUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<FooterUpdateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(result));
            }

        }

    }
}
