using AutoMapper;
using BussinessLayer.Interfaces;
using BussinessLayer.Mappings.AutoMapper;
using BussinessLayer.Services;
using BussinessLayer.ValidationRules.AboutValidation;
using BussinessLayer.ValidationRules.ContactValidation;
using BussinessLayer.ValidationRules.EducationValidation;
using BussinessLayer.ValidationRules.FooterValidation;
using BussinessLayer.ValidationRules.HeaderValidation;
using BussinessLayer.ValidationRules.PortfolioValidation;
using BussinessLayer.ValidationRules.ServiceValidation;
using BussinessLayer.ValidationRules.SkillValidation;
using BussinessLayer.ValidationRules.SubscribeValidation;
using BussinessLayer.ValidationRules.TestimonialValidation;
using BussinessLayer.ValidationRules.ToDoListValidation;
using DataAccessLayer.Context;
using DataAccessLayer.UnitOfWork;
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
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DependencyResolvers
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<CVContext>(opt =>
            {
                opt.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HKWebCVm;Trusted_Connection=True;TrustServerCertificate=True");
                opt.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });

            

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new CVProfile());
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<AboutUpdateDto>, AboutUpdateValidator>();
            services.AddTransient<IValidator<ContactCreateDto>, ContactCreateValidation>();
            services.AddTransient<IValidator<ContactUpdateDto>, ContactUpdateValidation>();
            services.AddTransient<IValidator<FooterUpdateDto>, FooterUpdateValidation>();
            services.AddTransient<IValidator<HeaderUpdateDto>, HeaderUpdateValidation>();
            services.AddTransient<IValidator<PortfolioCreateDto>, PortfolioCreateValidation>();
            services.AddTransient<IValidator<PortfolioUpdateDto>, PortfolioUpdateValidation>();
            services.AddTransient<IValidator<SkillCreateDto>, SkillCreateValidation>();
            services.AddTransient<IValidator<SkillUpdateDto>, SkillUpdateValidation>();
            services.AddTransient<IValidator<ServiceCreateDto>, ServiceCreateValidation>();
            services.AddTransient<IValidator<ServiceUpdateDto>, ServiceUpdateValidation>();
            services.AddTransient<IValidator<EducationCreateDto>, EducationCreateValidation>();
            services.AddTransient<IValidator<EducationUpdateDto>, EducationUpdateValidation>();
            services.AddTransient<IValidator<SubscribeCreateDto>, SubscribeCreateValidation>();
            services.AddTransient<IValidator<CreateToDoListDto>, ToDoListCreateValidation>();
            services.AddTransient<IValidator<UpdateToDoListDto>, ToDoListUpdateValidation>();
            services.AddTransient<IValidator<TestimonialCreateDto>, TestimonialCreateValidation>();
            services.AddTransient<IValidator<TestimonialUpdateDto>, TestimonialUpdateValidation>();

            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<IServicesService, ServiceService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<IHeaderService, HeaderService>();
            services.AddScoped<IFooterService, FooterService>();
            services.AddScoped<ISubscribeService, SubscribeService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IToDoListService, ToDoListService>();


        }
    }
}
