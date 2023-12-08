using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.TestimonialDtos;
using EntityLayer.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<TestimonialCreateDto> _createDtoValidator;
        private readonly IValidator<TestimonialUpdateDto> _updateDtoValidator;

        public TestimonialService(IUow uow, IMapper mapper, IValidator<TestimonialCreateDto> createDtoValidator, IValidator<TestimonialUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<TestimonialCreateDto>> Create(TestimonialCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Testimonial>().Create(_mapper.Map<Testimonial>(dto));
                await _uow.SaveChanges();
                return new Response<TestimonialCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<TestimonialCreateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(validationResult));
            }

        }

        public async Task<List<TestimonialListDto>> GetAll()
        {

            var data = _mapper.Map<List<TestimonialListDto>>(await _uow.GetRepository<Testimonial>().GetAll());
            return data;
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Testimonial>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removed = await _uow.GetRepository<Testimonial>().GetByFilter(x => x.Id == id);
            if (removed != null)
            {
                _uow.GetRepository<Testimonial>().Remove(removed);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

        public async Task<IResponse<TestimonialUpdateDto>> Update(TestimonialUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Testimonial>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Testimonial>().Update(_mapper.Map<Testimonial>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<TestimonialUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<TestimonialUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<TestimonialUpdateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(result));
            }

        }
    }
}
