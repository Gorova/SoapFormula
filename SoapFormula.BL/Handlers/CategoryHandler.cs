using System.Collections.Generic;
using AutoMapper;
using SoapFormula.BL.Handlers.Interface;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.Entities;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.BL.Handlers
{
    public class CategoryHandler : BaseHandler, IHandler<CategoryDto>
    {
        public CategoryHandler(IRepository repository)
            : base(repository)
        {
        }

        public void Add(CategoryDto categoryDto)
        {
            var category = Mapper.Map<CategoryDto, Category>(categoryDto);
            repository.Add(category);
            repository.Save();
        }

        public CategoryDto Get(int id)
        {
            var categoryDto = Mapper.Map<Category, CategoryDto>(repository.Get<Category>(id));

            return categoryDto;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categoriesDto = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(repository.Get<Category>());

            return categoriesDto;
        }

        public void Delete(int id)
        {
            repository.Delete(repository.Get<Category>(id));
            repository.Save();
        }

        public void Update(CategoryDto categoryDto)
        {
            var category = repository.Get<Category>(categoryDto.Id);
            Mapper.Map(categoryDto, category);
            repository.Save();
        }
    }
}
