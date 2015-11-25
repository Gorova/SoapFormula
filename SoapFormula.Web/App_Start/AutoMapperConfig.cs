using AutoMapper;
using SoapFormula.Common.DTO;
using SoapFormula.Web.ViewModel;

namespace SoapFormula.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            DtoToViewModel();
            ViewModelToDto();
        }

        public static void DtoToViewModel()
        {
            Mapper.CreateMap<CategoryDto, CategoryViewModel>();
            Mapper.CreateMap<FileDto, FileViewModel>();
            Mapper.CreateMap<ManufacturerDto, ManufacturerViewModel>();
            Mapper.CreateMap<ProductDto, ProductViewModel>();
        }

        public static void ViewModelToDto()
        {
            Mapper.CreateMap<CategoryViewModel, CategoryDto>();
            Mapper.CreateMap<FileViewModel, FileDto>();
            Mapper.CreateMap<ManufacturerViewModel, ManufacturerDto>();
            Mapper.CreateMap<ProductViewModel, ProductDto>();
        }
    }
}
