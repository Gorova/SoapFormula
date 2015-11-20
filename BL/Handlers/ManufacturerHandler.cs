using System.Collections.Generic;
using AutoMapper;
using BL.Handlers.Interface;
using SoapFormula.Common.DTO;
using SoapFormula.Common.Interface;
using SoapFormula.DAL.Entities;
using SoapFormula.DAL.Repository.Interface;

namespace BL.Handlers
{
    public class ManufacturerHandler : IHandler
    {
        private IRepository repository;

        public ManufacturerHandler(IRepository repositoryl)
        {
            this.repository = repositoryl;
        }

        public void Add(ManufacturerDto manufacturerDto)
        {
            var manufacturer = Mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto);
            repository.Add(manufacturer);
            repository.Save();
        }

        public IBase Get(int id)
        {
            var manufacturerDto = Mapper.Map<Manufacturer, ManufacturerDto>(repository.Get<Manufacturer>(id));

            return manufacturerDto;
        }

        public void Delete(int id)
        {
            var manufacturer = Mapper.Map<Manufacturer, ManufacturerDto>(repository.Get<Manufacturer>(id));
            repository.Delete(manufacturer);
        }

        public void Update(IBase manufacturerDto)
        {
            var manufacturer = repository.Get<Manufacturer>(manufacturerDto.Id);
            Mapper.Map(manufacturerDto, manufacturer);
            repository.Save();
        }

        public IEnumerable<IBase> GetAll()
        {
            var manufacturersDto =
                Mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ManufacturerDto>>(repository.Get<Manufacturer>());

            return manufacturersDto;
        }
    }
}
