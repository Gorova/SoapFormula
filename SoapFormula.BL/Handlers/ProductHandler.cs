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
    /// Class ProductHandler inherits from the BaseHandler class 
    /// implement IHandler generic interface type parameter is ProductDto
    /// entity from busines ligic layer
    /// contains main functional for add, get, delete and update DbSet entity
    /// </summary>
    public class ProductHandler : BaseHandler, IHandler<ProductDto>
    {
        /// <summary>
        /// Inherited constructor 
        /// </summary>
        /// <param name="repository">Requires argument IRepository type</param>
        public ProductHandler(IRepository repository) 
            : base(repository)
        {
        }

        /// <summary>
        /// Method Get find single entity DbSet
        /// mapping entity from Product DbSet to BLL ProdutDto
        /// </summary>
        /// <param name="id">Requires an integer argument</param>
        /// <returns>Return entity ProductDto type</returns>
        public ProductDto Get(int id)
        {
            var productDto = Mapper.Map<Product, ProductDto>(repository.Get<Product>(id));

            return productDto;
        }

        /// <summary>
        /// Method Get take entities as enumerable collection
        /// mapping entity from Produt DbSet to BLL ProdutDto
        /// </summary>
        /// <returns>Return IEnumerable collection parametrised by ProdutDto type</returns>
        public IEnumerable<ProductDto> Get()
        {
            var productsDto = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(repository.Get<Product>());
           
            return productsDto;
        }

        /// <summary>
        /// Method Add map entity from BLL ProdutDto to Produt DbSet
        /// select category for Product property
        /// calls repository`s methods for adding it to the table of DbSet
        /// and for saving changes to database 
        /// </summary>
        /// <param name="productDto">Requires argument type of ProdutDto</param>
        public void Add(ProductDto productDto)
        {
            var product = Mapper.Map<ProductDto, Product>(productDto);
            product.Categories = productDto.SelectedCategoriesId.Select(i => repository.Get<Category>(i)).ToList();

            repository.Add(product);
            repository.Save();
        }

        /// <summary>
        /// Method Update find DbSet entity by ProdutDto`s id
        /// selct category for Product property
        /// calls repository`s method for saving changes to database
        /// </summary>
        /// <param name="productDto">Requires argument type of ProdutDto</param>
        public void Update(ProductDto productDto)
        {
            var product = repository.Get<Product>(productDto.Id);
            Mapper.Map(productDto, product);
            product.Categories = productDto.SelectedCategoriesId.Select(i => repository.Get<Category>(i)).ToList();

            repository.Save();
        }

        /// <summary>
        /// Method Delete calls repository`s methods for deleting it to the table of DbSet
        /// and for saving changes to database
        /// </summary>
        /// <param name="id">Requires an integer argument</param>
        public void Delete(int id)
        {
            repository.Delete<Product>(id);
            repository.Save();
        }
    }
}
