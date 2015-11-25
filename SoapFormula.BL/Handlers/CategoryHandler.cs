using AutoMapper;
using SoapFormula.BL.Handlers.Interface;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.Entities;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.BL.Handlers
{
    public class CategoryHandler : IHandler<CategoryDto>
    {
        private readonly IRepository repository;

        public CategoryHandler(IRepository repository)
        {
            this.repository = repository;
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
