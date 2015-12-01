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
    public class ManufacturerHandler : BaseHandler, IHandler<ManufacturerDto>
    {
        /// <summary>
        /// Inherited constructor 
        /// </summary>
        /// <param name="repository">IRepository type argument</param>
        public ManufacturerHandler(IRepository repository) 
            : base(repository)
        {
        }

        /// <summary>
        /// Get single manufacturer
        /// </summary>
        /// <param name="id">Integer argument</param>
        /// <returns>Return entity ManufacturerDto type</returns>
       public ManufacturerDto Get(int id)
        {
            var manufacturerDto = Mapper.Map<Manufacturer, ManufacturerDto>(repository.Get<Manufacturer>(id));
            
            return manufacturerDto;
        }

        /// <summary>
        /// Get all manufacturers 
        /// </summary>
        /// <returns>Return IEnumerable collection of manufacturers</returns>
        public IEnumerable<ManufacturerDto> Get()
        {
            var manufacturersDto = Mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ManufacturerDto>>(repository.Get<Manufacturer>());

            return manufacturersDto;
        }

        /// <summary>
        /// Add manufacturer and save changes to database 
        /// </summary>
        /// <param name="manufacturerDto">ManufacturerDto type argument</param>
        public void Add(ManufacturerDto manufacturerDto)
        {
            var manufacturer = Mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto);

            repository.Add(manufacturer);
            repository.Save();
        }

        /// <summary>
        /// Save manufacturer`s changes
        /// </summary>
        /// <param name="manufacturerDto">ManufacturerDto type argument</param>
        public void Update(ManufacturerDto manufacturerDto)
        {
            var manufacturer = repository.Get<Manufacturer>(manufacturerDto.Id);
            Mapper.Map(manufacturerDto, manufacturer);

            repository.Save();
        }

        /// <summary>
        /// Delete manufacturer and save change to database
        /// </summary>
        /// <param name="id">Integer argument</param>
        public void Delete(int id)
        {
            repository.Delete<Manufacturer>(id);
            repository.Save();
        }
    }
}
