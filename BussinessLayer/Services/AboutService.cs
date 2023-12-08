using AutoMapper;
using BussinessLayer.Interfaces;
using FluentValidation;
using Common.ResponseObject;
using DataAccessLayer.UnitOfWork;
using DtoLayer.AboutDtos;
using DtoLayer.HeaderDtos;
using EntityLayer.Domains;
using BussinessLayer.Extensions;

namespace BussinessLayer.Services
{
    public class AboutService : IAboutService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AboutUpdateDto> _validator;

        public AboutService(IUow uow, IMapper mapper, IValidator<AboutUpdateDto> validator)
        {
            _uow = uow;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<AboutListDto>> GetAll()
        {

            var data = _mapper.Map<List<AboutListDto>>(await _uow.GetRepository<About>().GetAll());
            return data;
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<About>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse<AboutUpdateDto>> Update(AboutUpdateDto dto)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<About>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<About>().Update(_mapper.Map<About>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<AboutUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<AboutUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<AboutUpdateDto>(ResponseType.ValidationError, dto, ValidationResultExtensions.ConvertToCustomValidationError(result));
            }
        }
    }
}
