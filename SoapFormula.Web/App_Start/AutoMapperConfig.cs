using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Ninject;
using SoapFormula.Bootstrap;
using SoapFormula.Common.Entities;
using SoapFormula.DAL.Repository.Interface;
using SoapFormula.Web.ViewModel;
using WebGrease.Css.Extensions;

namespace SoapFormula.Web.App_Start
{
    public class AutoMapperConfig
    {
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
                .ForMember(i => i.Categories, map => map.MapFrom(p => p.CategoryIds.Select(i => new Category{ Id = i })));
        }
    }
   
}
