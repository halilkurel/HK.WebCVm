using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.ContactDtos;
using DtoLayer.SkillDtos;
using EntityLayer.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class ContactService : IContactService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<ContactCreateDto> _createDtoValidator;

        public ContactService(IUow uow, IMapper mapper, IValidator<ContactCreateDto> createDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<ContactCreateDto>> Create(ContactCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Contact>().Create(_mapper.Map<Contact>(dto));
                await _uow.SaveChanges();
                return new Response<ContactCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<ContactCreateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(validationResult));
            }

        }

        public async Task<List<ContactListDto>> GetAll()
        {

            var data = _mapper.Map<List<ContactListDto>>(await _uow.GetRepository<Contact>().GetAll());
            return data;
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Contact>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removed = await _uow.GetRepository<Contact>().GetByFilter(x => x.Id == id);
            if (removed != null)
            {
                _uow.GetRepository<Contact>().Remove(removed);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

    }
}
