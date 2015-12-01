using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Entities;

namespace SoapFormula.BL.Handlers
{
    /// <summary>
    /// Class inherits from the BaseHandler class, implement IHandler interface 
    /// contains main functional for add, get, delete and update DbSet entity
    /// </summary>
    public class ProductHandler : BaseHandler, IHandler<ProductDto>
    {
        /// <summary>
        /// Inherited constructor 
        /// </summary>
        /// <param name="repository">IRepository type argument</param>
        public ProductHandler(IRepository repository) 
            : base(repository)
        {
        }

        /// <summary>
        /// Get single product
        /// </summary>
        /// <param name="id">Integer argument</param>
        /// <returns>Return entity ProductDto type</returns>
        public ProductDto Get(int id)
        {
            var productDto = Mapper.Map<Product, ProductDto>(repository.Get<Product>(id));

            return productDto;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Return IEnumerable collection of products</returns>
        public IEnumerable<ProductDto> Get()
        {
            var productsDto = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(repository.Get<Product>());
           
            return productsDto;
        }

        /// <summary>
        /// Add products and save changes to database  
        /// </summary>
        /// <param name="productDto">ProductDto type argument </param>
        public void Add(ProductDto productDto)
        {
            var product = Mapper.Map<ProductDto, Product>(productDto);
            product.Categories = productDto.SelectedCategoriesId.Select(i => repository.Get<Category>(i)).ToList();

            repository.Add(product);
            repository.Save();
        }

        /// <summary>
        /// Save product`s changes
        /// </summary>
        /// <param name="productDto">ProductDto type argument</param>
        public void Update(ProductDto productDto)
        {
            var product = repository.Get<Product>(productDto.Id);
            Mapper.Map(productDto, product);
            product.Categories = productDto.SelectedCategoriesId.Select(i => repository.Get<Category>(i)).ToList();

            repository.Save();
        }

        /// <summary>
        /// Delete product and save change to database
        /// </summary>
        /// <param name="id">Integer argument</param>
        public void Delete(int id)
        {
            repository.Delete<Product>(id);
            repository.Save();
        }
    }
}
