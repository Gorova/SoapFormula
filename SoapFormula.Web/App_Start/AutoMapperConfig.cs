using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Description;
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
                
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductViewModel, Product>()
                .ForMember(i => i.Categories, map => map.MapFrom(p => (Method(p)))); 
        }

        static ICollection<Category> Method(ProductViewModel p)
        {
            var list = new List<Category>();
            
            foreach (var i in p.CategoryIds)
            {
               var m = repository.Get<Category>().FirstOrDefault(n => i == n.Id);
               list.Add(m);
            }
            
            return list;
        }
    }
}