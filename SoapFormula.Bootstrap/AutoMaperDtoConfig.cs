﻿using AutoMapper;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.Entities;

namespace SoapFormula.Bootstrap
{
    public class AutoMaperDtoConfig
    {
        public static void RegisterDtoMapping()
        {
            EntityToDto();
            DtoToEntity();
        }

        private static void EntityToDto()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<File, FileDto>();
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<Manufacturer, ManufacturerDto>();
        }

        private static void DtoToEntity()
        {
            Mapper.CreateMap<CategoryDto, Category>();
            Mapper.CreateMap<FileDto, File>();
            Mapper.CreateMap<ProductDto, Product>()
                .ForMember(d => d.Manufacturer, opt => opt.Ignore());
            Mapper.CreateMap<ManufacturerDto, Manufacturer>()
                .ForMember(d => d.Products, opt => opt.Ignore());
        }
    }
}

