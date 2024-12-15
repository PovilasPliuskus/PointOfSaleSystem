using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;

namespace PointOfSaleSystem.API.Repositories
{
    public class EstablishmentRepostitory : IEstablishmentRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public EstablishmentRepostitory(
            PointOfSaleSystemContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public Establishment Get(Guid id)
        {
            EstablishmentEntity? establishmentEntity = GetEstablishmentEntity(id);

            return establishmentEntity is null
                ? throw new Exception($"Establishment with Id {id} not found.")
                : _mapper.Map<Establishment>(establishmentEntity);
        }

        public List<Establishment> GetlAll()
        {
            List<EstablishmentEntity> establishmentEntities = _context.Establishments
                .Include(e => e.Employees)
                .Include(e => e.EstablishmentProducts)
                .Include(e => e.EstablishmentServices)
                .ToList();

            List<Establishment> establishments = _mapper.Map<List<Establishment>>(establishmentEntities);

            return establishments;
        }

        private EstablishmentEntity? GetEstablishmentEntity(Guid id)
        {
            return _context.Establishments
                .Include(e => e.Employees)
                .Include(e => e.EstablishmentProducts)
                .Include(e => e.EstablishmentServices)
                .FirstOrDefault(e => e.Id == id);
        }
    }

}
