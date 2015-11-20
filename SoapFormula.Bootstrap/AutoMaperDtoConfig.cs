using AutoMapper;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.Entities;

namespace SoapFormula.Bootstrap
{
    public class AutoMaperDtoConfig
    {
        public static void RegisterDtoMapping()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();

            Mapper.CreateMap<File, FileDto>();
            Mapper.CreateMap<FileDto, File>();

            Mapper.CreateMap<Manufacturer, ManufacturerDto>();
            Mapper.CreateMap<ManufacturerDto, Manufacturer>();

            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
        }
    }
}
