﻿using AutoMapper;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Company;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            List<CompanyEntity> companyEntities = _context.Companies.ToList();

            List<Company> companies = _mapper.Map<List<Company>>(companyEntities);

            return companies;
        }

        public void Update(UpdateCompanyRequest request)
        {
            CompanyEntity? companyEntity = GetCompanyEntity(request.Id)
                ?? throw new Exception($"Company with Id {request.Id} not found.");

            companyEntity.Code = request.Code;
            companyEntity.Name = request.Name;

            _context.Update(companyEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            CompanyEntity? companyEntity = GetCompanyEntity(id)
                ?? throw new Exception($"Company with Id {id} not found.");

            _context.Companies.Remove(companyEntity);

            _context.SaveChanges();
        }

        private CompanyEntity? GetCompanyEntity(Guid id)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == id);
        }
    }
}
