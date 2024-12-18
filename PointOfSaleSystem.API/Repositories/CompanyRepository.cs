using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Company;

namespace PointOfSaleSystem.API.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public CompanyRepository(
            PointOfSaleSystemContext context,
            IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public void Create(Company company)
        {
            CompanyEntity companyEntity = _mapper.Map<CompanyEntity>(company);

            _context.Companies.Add(companyEntity);

            _context.SaveChanges();
        }

        public Company Get(Guid id)
        {
            CompanyEntity? companyEntity = GetCompanyEntity(id);

            return companyEntity is null
                ? throw new Exception($"Company with Id {id} not found.")
                : _mapper.Map<Company>(companyEntity);
        }

        public List<Company> GetAll()
        {
            List<CompanyEntity> companyEntities = _context.Companies
                .Include(c => c.Establishments)
                    .ThenInclude(e => e.Employees)
                .Include(c => c.Establishments)
                    .ThenInclude(e => e.EstablishmentProducts)
                        .ThenInclude(ep => ep.Orders)
                .Include(c => c.Establishments)
                    .ThenInclude(e => e.EstablishmentServices)
                        .ThenInclude(es => es.Orders)
                .Include(c => c.Establishments)
                    .ThenInclude(e => e.FullOrders)
                .Include(c => c.CompanyProducts)
                .Include(c => c.CompanyServices)
                .ToList();

            List<Company> companies = _mapper.Map<List<Company>>(companyEntities);

            return companies;
        }

        public void Update(UpdateCompanyRequest request)
        {
            CompanyEntity? companyEntity = GetCompanyEntity(request.Id)
                ?? throw new Exception($"Company with Id {request.Id} not found.");

            companyEntity.Code = request.Code;
            companyEntity.Name = request.Name;
            companyEntity.UpdateTime = request.UpdateTime;

            _context.Update(companyEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            CompanyEntity? companyEntity = GetCompanyEntity(id)
                ?? throw new Exception($"Company with Id {id} not found.");

            var establishmentServiceIds = companyEntity.Establishments
                .SelectMany(e => e.EstablishmentServices)
                .Select(es => es.Id)
                .ToList();

            var establishmentProductIds = companyEntity.Establishments
                .SelectMany(e => e.EstablishmentProducts)
                .Select(ep => ep.Id)
                .ToList();

            if (establishmentServiceIds.Any() || establishmentProductIds.Any())
            {
                var ordersToDelete = _context.Orders
                    .Where(o => (o.fkEstablishmentService.HasValue && establishmentServiceIds.Contains(o.fkEstablishmentService.Value)) ||
                                (o.fkEstablishmentProduct.HasValue && establishmentProductIds.Contains(o.fkEstablishmentProduct.Value)))
                    .ToList();

                var fullOrders = _context.FullOrders.ToList();

                foreach (var order in ordersToDelete)
                {
                    var matchinFullOrder = fullOrders.FirstOrDefault(fo => fo.Id == order.fkFullOrderId);
                    if (matchinFullOrder is not null)
                    {
                        _context.FullOrders.Remove(matchinFullOrder);
                    }
                }

                _context.Orders.RemoveRange(ordersToDelete);
                _context.SaveChanges();
            }

            _context.Companies.Remove(companyEntity);

            _context.SaveChanges();
        }

        public List<Company> GetAllByEmployeeId(Guid employeeId)
        {
            List<Company> allCompanies = GetAll();
            List<Company> selectedCompanies = [];

            foreach (var company in allCompanies)
            {
                if (company.Establishments.Any(establishment =>
                establishment.Employees.Any(employee =>
                employee.Id == employeeId)))
                {
                    selectedCompanies.Add(company);
                }
            }

            return selectedCompanies;
        }

        private CompanyEntity? GetCompanyEntity(Guid id)
        {
            return _context.Companies
                .Include(c => c.Establishments)
                    .ThenInclude(e => e.Employees)
                .Include(c => c.Establishments)
                    .ThenInclude(e => e.EstablishmentProducts)
                        .ThenInclude(ep => ep.Orders)
                .Include(c => c.Establishments)
                    .ThenInclude(e => e.EstablishmentServices)
                        .ThenInclude(es => es.Orders)
                .Include(c => c.Establishments)
                    .ThenInclude(e => e.FullOrders)
                .Include(c => c.CompanyProducts)
                .Include(c => c.CompanyServices)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
