using System.Collections.Generic;
using AutoMapper;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Entities;

namespace SoapFormula.BL.Handlers
{
    /// <summary>
    /// class inherits from the BaseHandler class 
    /// IHandler implementation  type parameter is CategoryDto
    /// entity from busines ligic layer
    /// </summary>
    public class CategoryHandler : BaseHandler, IHandler<CategoryDto>
    {
        public CategoryHandler(IRepository repository)
            : base(repository)
        {
        }
        /// <summary>
        /// method accept id of entity 
        /// mapping entity from BLL Categoty to CategoryDto
        /// bethod return CategoryDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryDto Get(int id)
        {
            var categoryDto = Mapper.Map<Category, CategoryDto>(repository.Get<Category>(id));

            return categoryDto;
        }
        /// <summary>
        /// method return IEnumerable collection parametrised by CategoryDto type
        /// mapping entity from BLL Categoty to CategoryDto 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryDto> Get()
        {
            var categoriesDto = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(repository.Get<Category>());

            return categoriesDto;
        }
        /// <summary>
        /// method accepts entity BLL type of CategoryDto
        /// mapping entity from BLL CategoryDto to Category
        /// calls repository`s methods for adding it to the table of DbSet
        /// and for saving changes to database 
        /// </summary>
        /// <param name="categoryDto"></param>
        public void Add(CategoryDto categoryDto)
        {
            var category = Mapper.Map<CategoryDto, Category>(categoryDto);

            repository.Add(category);
            repository.Save();
        }
        /// <summary>
        /// method accepts entity BLL type of CategoryDto
        /// find entity in database by CategoryDto`s id
        /// mapping entity from BLL CategoryDto to Category
        /// and calls repository`s method for saving changes to database  
        /// </summary>
        /// <param name="categoryDto"></param>
        public void Update(CategoryDto categoryDto)
        {
            var category = repository.Get<Category>(categoryDto.Id);
            Mapper.Map(categoryDto, category);

            repository.Save();
        }
        /// <summary>
        /// method accept id of entity 
        /// calls repository`s methods for deleting it to the table of DbSet
        /// and for saving changes to database
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            repository.Delete<Category>(id);
            repository.Save();
        }
    }
}
