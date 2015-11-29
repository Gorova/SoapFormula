using System.Collections.Generic;
using AutoMapper;
using SoapFormula.BL.API.Handlers;
using SoapFormula.Common.DTO;
using SoapFormula.DAL.API.Repositories;
using SoapFormula.DAL.Entities;

namespace SoapFormula.BL.Handlers
{
    /// <summary>
    /// Class ManufacturerHandler inherits from the BaseHandler class 
    /// implement IHandler generic interface type parameter is ManufacturerDto
    /// entity from busines ligic layer
    /// contains main functional for add, get, delete and update DbSet entity
    /// </summary>
    public class ManufacturerHandler : BaseHandler, IHandler<ManufacturerDto>
    {
        /// <summary>
        /// Inherited constructor 
        /// </summary>
        /// <param name="repository">Requires argument IRepository type</param>
        public ManufacturerHandler(IRepository repository) 
            : base(repository)
        {
        }

        /// <summary>
        /// Method Get find single entity DbSet
        /// mapping entity from Manufacturer DbSet to BLL ManufactureryDto
        /// </summary>
        /// <param name="id">Requires an integer argument</param>
        /// <returns>Return entity ManufacturerDto type</returns>
       public ManufacturerDto Get(int id)
        {
            var manufacturerDto = Mapper.Map<Manufacturer, ManufacturerDto>(repository.Get<Manufacturer>(id));
            
            return manufacturerDto;
        }

        /// <summary>
        /// Method Get take entities as enumerable collection
        /// mapping entity from Manufacturer DbSet to BLL ManufacturerDto 
        /// </summary>
        /// <returns>Return IEnumerable collection parametrised by ManufacturerDto type</returns>
        public IEnumerable<ManufacturerDto> Get()
        {
            var manufacturersDto = Mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ManufacturerDto>>(repository.Get<Manufacturer>());

            return manufacturersDto;
        }

        /// <summary>
        /// Method Add map entity from BLL ManufacturerDto to Manufacturer DbSet
        /// calls repository`s methods for adding it to the table of DbSet
        /// and for saving changes to database 
        /// </summary>
        /// <param name="manufacturerDto">Requires argument type of ManufacturerDto</param>
        public void Add(ManufacturerDto manufacturerDto)
        {
            var manufacturer = Mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto);

            repository.Add(manufacturer);
            repository.Save();
        }

        /// <summary>
        /// Method Update find DbSet entity by ManufacturerDto`s id 
        /// and calls repository`s method for saving changes to database
        /// </summary>
        /// <param name="manufacturerDto">Requires argument type of ManufacturerDto</param>
        public void Update(ManufacturerDto manufacturerDto)
        {
            var manufacturer = repository.Get<Manufacturer>(manufacturerDto.Id);
            Mapper.Map(manufacturerDto, manufacturer);

            repository.Save();
        }

        /// <summary>
        /// Method Delete calls repository`s methods for deleting it to the table of DbSet
        /// and for saving changes to database
        /// </summary>
        /// <param name="id">Requires an integer argument</param>
        public void Delete(int id)
        {
            repository.Delete<Manufacturer>(id);
            repository.Save();
        }
    }
}
