using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public EstablishmentProduct Get(Guid id)
        {
            EstablishmentProductEntity? establishmentProductEntity = GetEstablishmentProductEntity(id);

            return establishmentProductEntity is null
                ? throw new Exception($"EstablishmentProduct with Id {id} not found.")
                : _mapper.Map<EstablishmentProduct>(establishmentProductEntity);
        }

        public List<EstablishmentProduct> GetAll()
        {
            List<EstablishmentProductEntity> establishmentProductEntities = _context.EstablishmentProducts.ToList();

            List<EstablishmentProduct> establishmentProducts = _mapper.Map<List<EstablishmentProduct>>(establishmentProductEntities);

            return establishmentProducts;
        }

        private EstablishmentProductEntity? GetEstablishmentProductEntity(Guid id)
        {
            return _context.EstablishmentProducts
                .Include(ep => ep.Orders)
                .FirstOrDefault(ep => ep.Id == id);
        }
    }
}
