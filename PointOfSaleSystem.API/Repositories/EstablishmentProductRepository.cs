using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.EstablishmentProduct;

namespace PointOfSaleSystem.API.Repositories
{
    public class EstablishmentProductRepository : IEstablishmentProductRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;
        private readonly IEstablishmentRepository _establishmentRepository;

        public EstablishmentProductRepository(PointOfSaleSystemContext context,
            IMapper mapper,
            IEstablishmentRepository establishmentRepository)
        {
            _context = context;
            _mapper = mapper;
            _establishmentRepository = establishmentRepository;
        }

        public void Create(AddEstablishmentProductRequest request)
        {
            EstablishmentProductEntity establishmentProductEntity = _mapper.Map<EstablishmentProductEntity>(request);

            _context.EstablishmentProducts.Add(establishmentProductEntity);

            _context.SaveChanges();
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
            List<EstablishmentProductEntity> establishmentProductEntities = _context.EstablishmentProducts
                .Include(ep => ep.Orders)
                .ToList();

            List<EstablishmentProduct> establishmentProducts = _mapper.Map<List<EstablishmentProduct>>(establishmentProductEntities);

            return establishmentProducts;
        }

        public void Update(UpdateEstablishmentProductRequest request)
        {
            EstablishmentProductEntity? establishmentProductEntity = GetEstablishmentProductEntity(request.Id)
                ?? throw new Exception($"EstablishmentProduct with Id {request.Id} not found.");

            establishmentProductEntity.Name = request.Name;
            establishmentProductEntity.Price = request.Price;
            establishmentProductEntity.AmountInStock = request.AmountInStock;
            establishmentProductEntity.Currency = (Models.Enums.CurrencyEnum)request.Currency;
            establishmentProductEntity.UpdateTime = request.UpdateTime;

            _context.Update(establishmentProductEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            EstablishmentProductEntity? establishmentProductEntity = GetEstablishmentProductEntity(id)
                ?? throw new Exception($"EstablishmentProduct with Id {id} not found.");

            _context.EstablishmentProducts.Remove(establishmentProductEntity);

            _context.SaveChanges();
        }

        public List<EstablishmentProduct> GetAllByEmployeeId(Guid id)
        {
            List<Establishment> allEstablishments = _establishmentRepository.GetAllByEmployeeId(id);
            List<EstablishmentProduct> establishmentProducts = [];

            foreach(var establishment in allEstablishments)
            {
                foreach(var product in establishment.EstablishmentProducts)
                {
                    establishmentProducts.Add(product);
                }
            }

            return establishmentProducts;
        }

        public List<EstablishmentProduct> GetEstablishmentProductsByEmployeeId(Guid id)
        {
            List<Establishment> allEstablishments = _establishmentRepository.GetByEmployeeId(id);
            List<EstablishmentProduct> establishmentProducts = [];

            foreach (var establishment in allEstablishments)
            {
                foreach (var product in establishment.EstablishmentProducts)
                {
                    establishmentProducts.Add(product);
                }
            }

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
