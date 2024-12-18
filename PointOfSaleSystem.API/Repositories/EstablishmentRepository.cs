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
        private readonly ICompanyRepository _companyRepository;

        public EstablishmentRepository(PointOfSaleSystemContext context,
            IMapper mapper,
            ICompanyRepository companyRepository)
        {
            _context = context;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public void Create(AddEstablishmentRequest establishment)
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
                    .ThenInclude(ep => ep.Orders)
                .Include(e => e.EstablishmentServices)
                    .ThenInclude(es => es.Orders)
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

        public List<Establishment> GetAllByEmployeeId(Guid employeeId)
        {
            List<Company> allCompanies = _companyRepository.GetAllByEmployeeId(employeeId);
            List<Establishment> selectedEstablishments = [];

            foreach (Company company in allCompanies)
            {
                foreach (var establishment in company.Establishments)
                {
                    selectedEstablishments.Add(establishment);
                }
            }

            return selectedEstablishments;
        }

        public List<Establishment> GetByEmployeeId(Guid employeeId)
        {
            List<Establishment> allEstablishments = GetAll();
            Establishment selectedEstablishment;

            foreach(var establishment in allEstablishments)
            {
                if (establishment.Employees.Any(employee =>
                employee.Id == employeeId))
                {
                    selectedEstablishment = establishment;
                    return [selectedEstablishment];

                }
            }

            return null;
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