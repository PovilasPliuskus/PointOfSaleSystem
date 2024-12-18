using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.CompanyProduct;

namespace PointOfSaleSystem.API.Repositories
{
    public class CompanyProductRepository : ICompanyProductRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompanyProductRepository(PointOfSaleSystemContext context,
            IMapper mapper,
            ICompanyRepository companyRepository)
        {
            _context = context;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public void Create(AddCompanyProductRequest request)
        {
            CompanyProductEntity companyProductEntity = _mapper.Map<CompanyProductEntity>(request);

            _context.CompanyProducts.Add(companyProductEntity);

            _context.SaveChanges();
        }

        public CompanyProduct Get(Guid id)
        {
            CompanyProductEntity? companyProductEntity = GetCompanyProductEntity(id);

            return companyProductEntity is null
                ? throw new Exception($"CompanyProduct with Id {id} not found.")
                : _mapper.Map<CompanyProduct>(companyProductEntity);
        }

        public List<CompanyProduct> GetAll()
        {
            List<CompanyProductEntity> companyProductEntities = _context.CompanyProducts.ToList();

            List<CompanyProduct> companyProducts = _mapper.Map<List<CompanyProduct>>(companyProductEntities);

            return companyProducts;
        }

        public void Update(UpdateCompanyProductRequest request)
        {
            CompanyProductEntity? companyProductEntity = GetCompanyProductEntity(request.Id)
                ?? throw new Exception($"CompanyProduct with Id {request.Id} not found.");

            companyProductEntity.Name = request.Name;
            companyProductEntity.AlcoholicBeverage = request.AlcoholicBeverage;
            companyProductEntity.UpdateTime = request.UpdateTime;

            _context.Update(companyProductEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            CompanyProductEntity? companyProductEntity = GetCompanyProductEntity(id)
                ?? throw new Exception($"CompanyProduct with Id {id} not found.");

            _context.CompanyProducts.Remove(companyProductEntity);

            _context.SaveChanges();
        }

        public List<CompanyProduct> GetAllByEmployeeId(Guid employeeId)
        {
            List<Company> companies = _companyRepository.GetAllByEmployeeId(employeeId);
            List<CompanyProduct> selectedProducts = [];

            foreach (var company in companies)
            {
                foreach (var product in company.CompanyProducts)
                {
                    selectedProducts.Add(product);
                }
            }

            return selectedProducts;
        }

        private CompanyProductEntity? GetCompanyProductEntity(Guid id)
        {
            return _context.CompanyProducts.FirstOrDefault(cp => cp.Id == id);
        }
    }
}
