using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Tax;

namespace PointOfSaleSystem.API.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public TaxRepository(
            PointOfSaleSystemContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(AddTaxRequest request)
        {
            TaxEntity taxEntity = _mapper.Map<TaxEntity>(request);

            _context.Taxes.Add(taxEntity);

            _context.SaveChanges();
        }

        public Tax Get(Guid id)
        {
            TaxEntity? taxEntity = GetTaxEntity(id);

            return taxEntity is null
                ? throw new Exception($"Tax with Id {id} not found.")
                : _mapper.Map<Tax>(taxEntity);
        }

        public List<Tax> GetAll()
        {
            List<TaxEntity> taxEntities = _context.Taxes.ToList();

            List<Tax> taxs = _mapper.Map<List<Tax>>(taxEntities);

            return taxs;
        }

        public void Update(UpdateTaxRequest request)
        {
            TaxEntity? taxEntity = GetTaxEntity(request.Id)
                ?? throw new Exception($"Tax with Id {request.Id} not found.");

            taxEntity.amount = request.amount;

            _context.Update(taxEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            TaxEntity? taxEntity = GetTaxEntity(id)
                ?? throw new Exception($"Tax with Id {id} not found.");

            _context.Taxes.Remove(taxEntity);

            _context.SaveChanges();
        }

        private TaxEntity? GetTaxEntity(Guid id)
        {
            return _context.Taxes.FirstOrDefault(c => c.Id == id);
        }
    }
}