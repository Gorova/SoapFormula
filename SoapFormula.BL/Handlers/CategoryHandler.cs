using System.Collections.Generic;
using AutoMapper;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Entities;

namespace SoapFormula.BL.Handlers
{
    public class CategoryHandler : BaseHandler, IHandler<CategoryDto>
    {
        public CategoryHandler(IRepository repository)
            : base(repository)
        {
        }
        
        public CategoryDto Get(int id)
        {
            var categoryDto = Mapper.Map<Category, CategoryDto>(repository.Get<Category>(id));

            return categoryDto;
        }

        public IEnumerable<CategoryDto> Get()
        {
            var categoriesDto = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(repository.Get<Category>());

            return categoriesDto;
        }

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
