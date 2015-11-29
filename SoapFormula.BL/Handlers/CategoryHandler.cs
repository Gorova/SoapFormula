using System.Collections.Generic;
using AutoMapper;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Entities;

namespace SoapFormula.BL.Handlers
{
    /// <summary>
    /// Class CategoryHandler inherits from the BaseHandler class 
    /// implement IHandler generic interface type parameter is CategoryDto
    /// entity from busines ligic layer
    /// contains main functional for add, get, delete and update DbSet entity
    /// </summary>
    public class CategoryHandler : BaseHandler, IHandler<CategoryDto>
    {
        /// <summary>
        /// Inherited constructor
        /// </summary>
        /// <param name="repository">Requires argument IRepository type</param>
        public CategoryHandler(IRepository repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Method Get find single entity DbSet 
        /// mapping entity from Categoty DbSet to BLL CategoryDto
        /// </summary>
        /// <param name="id">Requires an integer argument</param>
        /// <returns>Return entity CategoryDto type</returns>
        public CategoryDto Get(int id)
        {
            var categoryDto = Mapper.Map<Category, CategoryDto>(repository.Get<Category>(id));

            return categoryDto;
        }

        /// <summary>
        /// Method Get take entities as enumerable collection
        /// mapping entity from Categoty DbSet to BLL CategoryDto 
        /// </summary>
        /// <returns>Return IEnumerable collection parametrised by CategoryDto type</returns>
        public IEnumerable<CategoryDto> Get()
        {
            var categoriesDto = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(repository.Get<Category>());

            return categoriesDto;
        }

        /// <summary>
        /// Method Add map entity from BLL CategoryDto to Category DbSet
        /// calls repository`s methods for adding it to the table of DbSet
        /// and for saving changes to database 
        /// </summary>
        /// <param name="categoryDto">Requires argument type of CategoryDto</param>
        public void Add(CategoryDto categoryDto)
        {
            var category = Mapper.Map<CategoryDto, Category>(categoryDto);

            repository.Add(category);
            repository.Save();
        }

        /// <summary>
        /// Method Update find DbSet entity by CategoryDto`s id
        /// mapping entity from BLL CategoryDto to Category
        /// and calls repository`s method for saving changes to database  
        /// </summary>
        /// <param name="categoryDto">Requires argument type of CategoryDto</param>
        public void Update(CategoryDto categoryDto)
        {
            var category = repository.Get<Category>(categoryDto.Id);
            Mapper.Map(categoryDto, category);

            repository.Save();
        }

        /// <summary>
        /// Method Delete calls repository`s methods for deleting it to the table of DbSet
        /// and for saving changes to database
        /// </summary>
        /// <param name="id">Requires an integer argument</param>
        public void Delete(int id)
        {
            repository.Delete<Category>(id);
            repository.Save();
        }
    }
}
