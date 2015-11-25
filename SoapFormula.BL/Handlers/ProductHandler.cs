using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SoapFormula.BL.Handlers.Interface;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.Entities;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.BL.Handlers
{
    public class ProductHandler : IHandler<ProductDto>
    {
        private readonly IRepository repository;

        public ProductHandler(IRepository repository)
        {
            this.repository = repository;
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
