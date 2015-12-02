using System.Collections.Generic;
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
    public class CategoryHandler : BaseHandler, IHandler<CategoryDto>
    {
        /// <summary>
        /// Inherited constructor
        /// </summary>
        /// <param name="repository">IRepository type argument</param>
        public CategoryHandler(IRepository repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Get single category 
        /// </summary>
        /// <param name="id">Integer argument</param>
        /// <returns>Return entity CategoryDto type</returns>
        public CategoryDto Get(int id)
        {
            var categoryDto = Mapper.Map<Category, CategoryDto>(repository.Get<Category>(id));

            return categoryDto;
        }

        /// <summary>
        /// Get all categories 
        /// </summary>
        /// <returns>Return IEnumerable collection of categories</returns>
        public IEnumerable<CategoryDto> Get()
        {
            var categoriesDto = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(repository.Get<Category>());

            return categoriesDto;
        }

        /// <summary>
        /// Add category and save changes to database 
        /// </summary>
        /// <param name="categoryDto">Category type argument</param>
        public void Add(CategoryDto categoryDto)
        {
            var category = Mapper.Map<CategoryDto, Category>(categoryDto);

            repository.Add(category);
            repository.Save();
        }

        /// <summary>
        /// Save category`s changes 
        /// </summary>
        /// <param name="categoryDto">CategoryDto type argument</param>
        public void Update(CategoryDto categoryDto)
        {
            var category = repository.Get<Category>(categoryDto.Id);
            Mapper.Map(categoryDto, category);

            repository.Save();
        }

        /// <summary>
        /// Delete category and save change to database
        /// </summary>
        /// <param name="id">Integer argument</param>
        public void Delete(int id)
        {
            repository.Delete<Category>(id);
            repository.Save();
        }
    }
}
