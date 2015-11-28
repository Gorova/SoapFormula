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
        /// comparison entity from BLL Categoty to CategoryDto
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
        /// comparison entity from BLL Categoty to CategoryDto 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryDto> Get()
        {
            var categoriesDto = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(repository.Get<Category>());

            return categoriesDto;
        }
        /// <summary>
        /// method get entity BLL type of CategoryDto
        /// comparison entity from BLL CategoryDto to Category
        /// calls repository`s method for adding it to the table of DbSet
        /// </summary>
        /// <param name="categoryDto"></param>
        public void Add(CategoryDto categoryDto)
        {
            var category = Mapper.Map<CategoryDto, Category>(categoryDto);

            repository.Add(category);
            repository.Save();
        }

        public void Update(CategoryDto categoryDto)
        {
            var category = repository.Get<Category>(categoryDto.Id);
            Mapper.Map(categoryDto, category);

            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete<Category>(id);
            repository.Save();
        }
    }
}
