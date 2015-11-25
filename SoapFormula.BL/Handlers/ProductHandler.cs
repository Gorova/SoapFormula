using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SoapFormula.BL.Handlers.Interface;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.Entities;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.BL.Handlers
{
    public class ProductHandler : BaseHandler, IHandler<ProductDto>
    {
        public ProductHandler(IRepository repository) : base(repository)
        {
        }

        public void Add(ProductDto productDto)
        {
            var product = Mapper.Map<ProductDto, Product>(productDto);
            product.Categories = productDto.SelectedIds.Select(i => repository.Get<Category>(i)).ToList();
            product.Manufacturer = repository.Get<Manufacturer>(productDto.ManufacturerId);
            repository.Add(product);
            repository.Save();
        }

        public ProductDto Get(int id)
        {
            var productDto = Mapper.Map<Product, ProductDto>(repository.Get<Product>(id));

            return productDto;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var productsDto = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(repository.Get<Product>());

            return productsDto;
        }

        public void Delete(int id)
        {
            repository.Delete(repository.Get<Product>(id));
            repository.Save();
        }

        public void Update(ProductDto productDto)
        {
            var product = repository.Get<Product>(productDto.Id);
            Mapper.Map(productDto, product);
            product.Categories = productDto.SelectedIds.Select(i => repository.Get<Category>(i)).ToList();
            product.Manufacturer = repository.Get<Manufacturer>(productDto.ManufacturerId);
            repository.Save();
        }
    }
}
