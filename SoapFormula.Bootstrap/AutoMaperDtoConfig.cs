using System.Linq;
using AutoMapper;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.Entities;

namespace SoapFormula.Bootstrap
{
    /// <summary>
    /// Class AutoMaperDtoConfig with functional of projecting DbSet entities and entities from BLL
    /// </summary>
    public class AutoMaperDtoConfig
    {
        /// <summary>
        /// static constructor which call two methods:
        /// EntityToDto - projecting DbSet entities to entities from BLL
        /// DtoToEntity - projecting BLL entities to DbSet entities
        /// </summary>
        public static void RegisterDtoMapping()
        {
            EntityToDto();
            DtoToEntity();
        }

        private static void EntityToDto()
        {
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<File, FileDto>();
            Mapper.CreateMap<Product, ProductDto>()
                .ForMember(d => d.SelectedCategoriesId, opt => opt.MapFrom(i => i.Categories.Select(n =>n.Id)));
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

