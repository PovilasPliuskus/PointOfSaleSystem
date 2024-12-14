using AutoMapper;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;

namespace PointOfSaleSystem.API.Repositories
{
    public class EstablishmentProductRepository : IEstablishmentProductRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public EstablishmentProductRepository(PointOfSaleSystemContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<EstablishmentProduct> GetAll()
        {
            List<EstablishmentProductEntity> establishmentProductEntities = _context.EstablishmentProducts.ToList();

            List<EstablishmentProduct> establishmentProducts = _mapper.Map<List<EstablishmentProduct>>(establishmentProductEntities);

            return establishmentProducts;
        }
    }
}
