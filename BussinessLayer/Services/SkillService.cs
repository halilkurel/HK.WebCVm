using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
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
    public class SkillService : ISkillService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<SkillCreateDto> _createDtoValidator;
        private readonly IValidator<SkillUpdateDto> _updateDtoValidator;

        public SkillService(IUow uow, IMapper mapper, IValidator<SkillCreateDto> createDtoValidator, IValidator<SkillUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }



        public async Task<List<SkillListDto>> GetAll()
        {

            var data = _mapper.Map<List<SkillListDto>>(await _uow.GetRepository<Skill>().GetAll());
            return data;
        }

        public async Task<IResponse<SkillCreateDto>> Create(SkillCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Skill>().Create(_mapper.Map<Skill>(dto));
                await _uow.SaveChanges();
                return new Response<SkillCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<SkillCreateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(validationResult));
            }

        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Skill>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removed = await _uow.GetRepository<Skill>().GetByFilter(x => x.Id == id);
            if (removed != null)
            {
                _uow.GetRepository<Skill>().Remove(removed);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

        public async Task<IResponse<SkillUpdateDto>> Update(SkillUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Skill>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Skill>().Update(_mapper.Map<Skill>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<SkillUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<SkillUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<SkillUpdateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(result));
            }

        }
    }
}
