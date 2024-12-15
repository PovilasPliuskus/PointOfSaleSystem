using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Establishment;

namespace PointOfSaleSystem.API.Repositories
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public EstablishmentRepository(PointOfSaleSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(Establishment establishment)
        {
            EstablishmentEntity establishmentEntity = _mapper.Map<EstablishmentEntity>(establishment);
            _context.Establishments.Add(establishmentEntity);
            _context.SaveChanges();
        }

        public Establishment Get(Guid id)
        {
            EstablishmentEntity? establishmentEntity = GetEstablishmentEntity(id);

            return establishmentEntity is null
                ? throw new Exception($"Establishment with Id {id} not found.")
                : _mapper.Map<Establishment>(establishmentEntity);
        }

        public List<Establishment> GetAll()
        {
            List<EstablishmentEntity> establishmentEntities = _context.Establishments
                .Include(e => e.Employees)
                .Include(e => e.EstablishmentProducts)
                .Include(e => e.EstablishmentServices)
                .ToList();

            List<Establishment> establishments = _mapper.Map<List<Establishment>>(establishmentEntities);

            return establishments;
        }

        public void Update(UpdateEstablishmentRequest request)
        {
            EstablishmentEntity? establishmentEntity = GetEstablishmentEntity(request.Id)
                ?? throw new Exception($"Establishment with Id {request.Id} not found.");
            establishmentEntity.Code = request.Code;
            establishmentEntity.Name = request.Name;
            _context.Update(establishmentEntity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            EstablishmentEntity? establishmentEntity = GetEstablishmentEntity(id)
                ?? throw new Exception($"Establishment with Id {id} not found.");
            _context.Establishments.Remove(establishmentEntity);
            _context.SaveChanges();
        }

        private EstablishmentEntity? GetEstablishmentEntity(Guid id)
        {
            return _context.Establishments.FirstOrDefault(e => e.Id == id);
        }
    }
}