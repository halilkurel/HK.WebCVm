using AutoMapper;
using DtoLayer.AboutDtos;
using DtoLayer.ContactDtos;
using DtoLayer.EducationDtos;
using DtoLayer.FooterDtos;
using DtoLayer.HeaderDtos;
using DtoLayer.PortfolioDtos;
using DtoLayer.ServicesDtos;
using DtoLayer.SkillDtos;
using DtoLayer.SubscribeDtos;
using DtoLayer.TestimonialDtos;
using DtoLayer.ToDoListDtos;
using EntityLayer.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Mappings.AutoMapper
{
    public class CVProfile : Profile
    {
        public CVProfile()
        {
            CreateMap<About,AboutListDto>().ReverseMap();
            CreateMap<About,AboutUpdateDto>().ReverseMap();
            CreateMap<AboutListDto,AboutUpdateDto>().ReverseMap();

            CreateMap<Contact, ContactListDto>().ReverseMap();
            CreateMap<Contact, ContactCreateDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();
            CreateMap<ContactListDto, ContactUpdateDto>().ReverseMap();


            CreateMap<Footer, FooterListDto>().ReverseMap();
            CreateMap<Footer, FooterUpdateDto>().ReverseMap();
            CreateMap<FooterListDto, FooterUpdateDto>().ReverseMap();

            CreateMap<Header, HeaderListDto>().ReverseMap();
            CreateMap<Header, HeaderUpdateDto>().ReverseMap();
            CreateMap<HeaderListDto, HeaderUpdateDto>().ReverseMap();

            CreateMap<Portfolio, PortfolioListDto>().ReverseMap();
            CreateMap<Portfolio, PortfolioUpdateDto>().ReverseMap();
            CreateMap<Portfolio, PortfolioCreateDto>().ReverseMap();
            CreateMap<PortfolioListDto, PortfolioUpdateDto>().ReverseMap();

            CreateMap<Service, ServicesListDto>().ReverseMap();
            CreateMap<Service, ServiceUpdateDto>().ReverseMap();
            CreateMap<Service, ServiceCreateDto>().ReverseMap();
            CreateMap<ServicesListDto, ServiceUpdateDto>().ReverseMap();

            CreateMap<Skill, SkillListDto>().ReverseMap();
            CreateMap<Skill, SkillUpdateDto>().ReverseMap();
            CreateMap<Skill, SkillCreateDto>().ReverseMap();
            CreateMap<SkillListDto, SkillListDto>().ReverseMap();

            CreateMap<Subscribe, SubscribeListDto>().ReverseMap();
            CreateMap<Subscribe, SubscribeCreateDto>().ReverseMap();


            CreateMap<Testimonial, TestimonialListDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialUpdateDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialCreateDto>().ReverseMap();
            CreateMap<TestimonialListDto, TestimonialUpdateDto>().ReverseMap();

            CreateMap<Education, EducationListDto>().ReverseMap();
            CreateMap<Education, EducationCreateDto>().ReverseMap();
            CreateMap<Education, EducationUpdateDto>().ReverseMap();
            CreateMap<EducationListDto, EducationUpdateDto>().ReverseMap();

            CreateMap<ToDoList, ListToDoListDto>().ReverseMap();
            CreateMap<ToDoList, CreateToDoListDto>().ReverseMap();
            CreateMap<ToDoList, UpdateToDoListDto>().ReverseMap();
            CreateMap<ListToDoListDto, UpdateToDoListDto>().ReverseMap();


        }
    }
}
