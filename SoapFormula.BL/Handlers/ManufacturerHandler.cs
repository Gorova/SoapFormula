using System.Collections.Generic;
using AutoMapper;
using SoapFormula.BL.Handlers.Interface;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.Entities;
using SoapFormula.DAL.Repository.Interface;

namespace SoapFormula.BL.Handlers
{
    public class ManufacturerHandler : BaseHandler, IHandler<ManufacturerDto>
    {
        public ManufacturerHandler(IRepository repository) : base(repository)
        {
        }

        public void Add(ManufacturerDto manufacturerDto)
        {
            var manufacturer = Mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto);
            repository.Add(manufacturer);
            repository.Save();
        }

        public ManufacturerDto Get(int id)
        {
            var manufacturerDto = Mapper.Map<Manufacturer, ManufacturerDto>(repository.Get<Manufacturer>(id));
            
            return manufacturerDto;
        }

        public IEnumerable<ManufacturerDto> GetAll()
        {
            var manufacturersDto = Mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ManufacturerDto>>(repository.Get<Manufacturer>());

            return manufacturersDto;
        }

        public void Delete(int id)
        {
            repository.Delete(repository.Get<Manufacturer>(id));
            repository.Save();
        }
        
        public void Update(ManufacturerDto manufacturerDto)
        {
            var manufacturer = repository.Get<Manufacturer>(manufacturerDto.Id);
            Mapper.Map(manufacturerDto, manufacturer);
            repository.Save();
        }
    }
}
