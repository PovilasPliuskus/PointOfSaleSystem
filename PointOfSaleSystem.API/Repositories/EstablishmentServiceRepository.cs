using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.EstablishmentService;

namespace PointOfSaleSystem.API.Repositories
{
    public class EstablishmentServiceRepository : IEstablishmentServiceRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;
        private readonly IEstablishmentRepository _establishmentRepository;

        public EstablishmentServiceRepository(PointOfSaleSystemContext context,
            IMapper mapper,
            IEstablishmentRepository establishmentRepository)
        {
            _context = context;
            _mapper = mapper;
            _establishmentRepository = establishmentRepository;
        }

        public void Create(AddEstablishmentServiceRequest request)
        {
            EstablishmentServiceEntity establishmentServiceEntity = _mapper.Map<EstablishmentServiceEntity>(request);

            _context.EstablishmentServices.Add(establishmentServiceEntity);

            _context.SaveChanges();
        }

        public EstablishmentService Get(Guid id)
        {
            EstablishmentServiceEntity? establishmentServiceEntity = GetEstablishmentServiceEntity(id);

            return establishmentServiceEntity is null
                ? throw new Exception($"EstablishmentService with Id {id} not found.")
                : _mapper.Map<EstablishmentService>(establishmentServiceEntity);
        }

        public List<EstablishmentService> GetAll()
        {
            List<EstablishmentServiceEntity> establishmentServiceEntities = _context.EstablishmentServices
                .Include(es => es.Orders)
                .ToList();

            List<EstablishmentService> establishmentServices = _mapper.Map<List<EstablishmentService>>(establishmentServiceEntities);

            return establishmentServices;
        }

        public void Update(UpdateEstablishmentServiceRequest request)
        {
            EstablishmentServiceEntity? establishmentServiceEntity = GetEstablishmentServiceEntity(request.Id)
                ?? throw new Exception($"EstablishmentService with Id {request.Id} not found.");

            establishmentServiceEntity.Name = request.Name;
            establishmentServiceEntity.Price = request.Price;
            establishmentServiceEntity.Currency = (CurrencyEnum)request.Currency;
            establishmentServiceEntity.UpdateTime = request.UpdateTime;

            _context.Update(establishmentServiceEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            EstablishmentServiceEntity? establishmentServiceEntity = GetEstablishmentServiceEntity(id)
                ?? throw new Exception($"EstablishmentService with Id {id} not found.");

            _context.EstablishmentServices.Remove(establishmentServiceEntity);

            _context.SaveChanges();
        }

        public List<EstablishmentService> GetAllByEmployeeId(Guid employeeId)
        {
            List<Establishment> allEstablishments = _establishmentRepository.GetAllByEmployeeId(employeeId);
            List<EstablishmentService> selectedServices = [];

            foreach(var establishment in allEstablishments)
            {
                foreach(var service in establishment.EstablishmentServices)
                {
                    selectedServices.Add(service);
                }
            }

            return selectedServices;
        }

        public List<EstablishmentService> GetEstablishmentServiceByEmployeeId(Guid employeeId)
        {
            List<Establishment> allEstablishments = _establishmentRepository.GetByEmployeeId(employeeId);
            List<EstablishmentService> selectedServices = [];

            foreach (var establishment in allEstablishments)
            {
                foreach (var service in establishment.EstablishmentServices)
                {
                    selectedServices.Add(service);
                }
            }

            return selectedServices;
        }

        private EstablishmentServiceEntity? GetEstablishmentServiceEntity(Guid id)
        {
            return _context.EstablishmentServices
                .Include(es => es.Orders)
                .FirstOrDefault(es => es.Id == id);
        }
    }
}
