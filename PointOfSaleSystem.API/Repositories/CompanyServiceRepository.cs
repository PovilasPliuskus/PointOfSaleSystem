using AutoMapper;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.CompanyService;

namespace PointOfSaleSystem.API.Repositories
{
    public class CompanyServiceRepository : ICompanyServiceRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public CompanyServiceRepository(PointOfSaleSystemContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(AddCompanyServiceRequest request)
        {
            CompanyServiceEntity companyServiceEntity = _mapper.Map<CompanyServiceEntity>(request);

            _context.CompanyServices.Add(companyServiceEntity);

            _context.SaveChanges();
        }

        public Models.CompanyService Get(Guid id)
        {
            CompanyServiceEntity? companyServiceEntity = GetCompanyServiceEntity(id);

            return companyServiceEntity is null
                ? throw new Exception($"CompanyService with Id {id} not found.")
                : _mapper.Map<Models.CompanyService>(companyServiceEntity);
        }

        public List<Models.CompanyService> GetAll()
        {
            List<CompanyServiceEntity> companyServiceEntities = _context.CompanyServices.ToList();

            List<Models.CompanyService> companyServices = _mapper.Map<List<Models.CompanyService>>(companyServiceEntities);

            return companyServices;
        }

        public void Update(UpdateCompanyServiceRequest request)
        {
            CompanyServiceEntity? companyServiceEntity = GetCompanyServiceEntity(request.Id)
                ?? throw new Exception($"CompanyService with Id {request.Id} not found.");

            companyServiceEntity.Name = request.Name;
            companyServiceEntity.UpdateTime = request.UpdateTime;

            _context.Update(companyServiceEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            CompanyServiceEntity? companyServiceEntity = GetCompanyServiceEntity(id)
                ?? throw new Exception($"CompanyService with Id {id} not found.");

            _context.CompanyServices.Remove(companyServiceEntity);

            _context.SaveChanges();
        }

        private CompanyServiceEntity? GetCompanyServiceEntity(Guid id)
        {
            return _context.CompanyServices.FirstOrDefault(cs => cs.Id == id);
        }
    }
}
