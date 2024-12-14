using AutoMapper;
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

        public List<EstablishmentService> GetAll()
        {
            List<EstablishmentServiceEntity> establishmentServiceEntities = _context.EstablishmentServices.ToList();

            List<EstablishmentService> establishmentServices = _mapper.Map<List<EstablishmentService>>(establishmentServiceEntities);

            return establishmentServices;
        }
    }
}
