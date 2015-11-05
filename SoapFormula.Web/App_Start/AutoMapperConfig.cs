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
             //   .ForMember(i => i.Products, map => map.MapFrom(p => CreateListItems(p)));
            Mapper.CreateMap<ManufacturerViewModel, Manufacturer>();
                

            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductViewModel, Product>();
        }

       //private static IEnumerable<SelectListItem> CreateListItems(Manufacturer m)
       // {
       //     var list = repository.Get<Product>()
       //         .Select(i => new SelectListItem {Text = i.Name, Value = i.Id.ToString()});
       //     return list;
       // }
    }
}