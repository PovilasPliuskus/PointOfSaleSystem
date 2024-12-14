using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;

namespace PointOfSaleSystem.API.Repositories
{
    public class EstablishmentServiceRepository : IEstablishmentServiceRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public EstablishmentServiceRepository(PointOfSaleSystemContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EstablishmentService Get(Guid id)
        {
            EstablishmentServiceEntity? establishmentServiceEntity = GetEstablishmentServiceEntity(id);

            return establishmentServiceEntity is null
                ? throw new Exception($"EstablishmentService with Id {id} not found.")
                : _mapper.Map<EstablishmentService>(establishmentServiceEntity);
        }

        public List<EstablishmentService> GetAll()
        {
            List<EstablishmentServiceEntity> establishmentServiceEntities = _context.EstablishmentServices.ToList();

            List<EstablishmentService> establishmentServices = _mapper.Map<List<EstablishmentService>>(establishmentServiceEntities);

            return establishmentServices;
        }

        private EstablishmentServiceEntity? GetEstablishmentServiceEntity(Guid id)
        {
            return _context.EstablishmentServices
                .Include(es => es.Orders)
                .FirstOrDefault(es => es.Id == id);
        }
    }
}
