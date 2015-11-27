using System.Collections.Generic;
using AutoMapper;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Entities;

namespace SoapFormula.BL.Handlers
{
    public class ManufacturerHandler : BaseHandler, IHandler<ManufacturerDto>
    {
        public ManufacturerHandler(IRepository repository) 
            : base(repository)
        {
        }

       public ManufacturerDto Get(int id)
        {
            var manufacturerDto = Mapper.Map<Manufacturer, ManufacturerDto>(repository.Get<Manufacturer>(id));
            
            return manufacturerDto;
        }

        public IEnumerable<ManufacturerDto> Get()
        {
            var manufacturersDto = Mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ManufacturerDto>>(repository.Get<Manufacturer>());

            return manufacturersDto;
        }

        public void Add(ManufacturerDto manufacturerDto)
        {
            var manufacturer = Mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto);

            repository.Add(manufacturer);
            repository.Save();
        }

        public void Update(ManufacturerDto manufacturerDto)
        {
            var manufacturer = repository.Get<Manufacturer>(manufacturerDto.Id);
            Mapper.Map(manufacturerDto, manufacturer);

            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete<Manufacturer>(id);
            repository.Save();
        }
    }
}
