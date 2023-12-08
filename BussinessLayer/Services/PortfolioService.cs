using AutoMapper;
using BussinessLayer.Extensions;
using BussinessLayer.Interfaces;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.PortfolioDtos;
using EntityLayer.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<PortfolioCreateDto> _createDtoValidator;
        private readonly IValidator<PortfolioUpdateDto> _updateDtoValidator;

        public PortfolioService(IUow uow, IMapper mapper, IValidator<PortfolioCreateDto> createDtoValidator, IValidator<PortfolioUpdateDto> updateDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<PortfolioCreateDto>> Create(PortfolioCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Portfolio>().Create(_mapper.Map<Portfolio>(dto));
                await _uow.SaveChanges();
                return new Response<PortfolioCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                return new Response<PortfolioCreateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(validationResult));
            }

        }

        public async Task<List<PortfolioListDto>> GetAll()
        {

            var data = _mapper.Map<List<PortfolioListDto>>(await _uow.GetRepository<Portfolio>().GetAll());
            return data;
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Portfolio>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removed = await _uow.GetRepository<Portfolio>().GetByFilter(x => x.Id == id);
            if (removed != null)
            {
                _uow.GetRepository<Portfolio>().Remove(removed);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");

        }

        public async Task<IResponse<PortfolioUpdateDto>> Update(PortfolioUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Portfolio>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Portfolio>().Update(_mapper.Map<Portfolio>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<PortfolioUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<PortfolioUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<PortfolioUpdateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(result));
            }

        }
    }
}
