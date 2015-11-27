using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Entities;

namespace SoapFormula.BL.Handlers
{
    public class ProductHandler : BaseHandler, IHandler<ProductDto>
    {
        public ProductHandler(IRepository repository) 
            : base(repository)
        {
        }

        public ProductDto Get(int id)
        {
            var productDto = Mapper.Map<Product, ProductDto>(repository.Get<Product>(id));

            return productDto;
        }

        public IEnumerable<ProductDto> Get()
        {
            var productsDto = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(repository.Get<Product>());

            return productsDto;
        }

        public void Add(ProductDto productDto)
        {
            var product = Mapper.Map<ProductDto, Product>(productDto);
            product.Categories = productDto.SelectedIds.Select(i => repository.Get<Category>(i)).ToList();

            repository.Add(product);
            repository.Save();
        }

        public void Update(ProductDto productDto)
        {
            var product = repository.Get<Product>(productDto.Id);
            Mapper.Map(productDto, product);
            product.Categories = productDto.SelectedIds.Select(i => repository.Get<Category>(i)).ToList();

            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete<Product>(id);
            repository.Save();
        }
    }
}
