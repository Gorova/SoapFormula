using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SoapFormula.Common.Entities;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();

            Mapper.CreateMap<File, FileViewModel>();

            Mapper.CreateMap<Manufacturer, ManufacturerViewModel>();

            Mapper.CreateMap<Product, ProductViewModel>();
        }
    }
}