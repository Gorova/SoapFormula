using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.App_Start
{
    public class AutoMapperConfig
    {
        static IRepository repository;

        static AutoMapperConfig()
        {
            var kernel = Kernel.Initialize();
            repository = kernel.Get<IRepository>();
        }

        public static void RegisterMapping()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryViewModel, Category>();

            Mapper.CreateMap<File, FileViewModel>();
            Mapper.CreateMap<FileViewModel, File>();

            Mapper.CreateMap<Manufacturer, ManufacturerViewModel>();
            Mapper.CreateMap<ManufacturerViewModel, Manufacturer>();

            Mapper.CreateMap<Product, ProductViewModel>();//.ForMember(i => i.ManufacturerItems, map => map.MapFrom(p => Method(p.ManufacturerId)));
            Mapper.CreateMap<ProductViewModel, Product>();
        }

        private static IEnumerable<SelectListItem> Method( int id)
        {
            var a = repository.Get<Manufacturer>().OrderBy(i=>i.Name)
                .Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString(), Selected = (i.Id==id)});
            return a;
        }
    }
}