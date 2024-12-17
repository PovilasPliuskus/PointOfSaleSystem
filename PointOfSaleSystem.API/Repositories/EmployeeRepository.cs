using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PointOfSaleSystem.API.Context;
using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.Models.Entities;
using PointOfSaleSystem.API.Models.Enums;
using PointOfSaleSystem.API.Repositories.Interfaces;
using PointOfSaleSystem.API.RequestBodies.Employees;

namespace PointOfSaleSystem.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PointOfSaleSystemContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(
            PointOfSaleSystemContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(AddEmployeeRequest request)
        {
            EmployeeEntity employeeEntity = _mapper.Map<EmployeeEntity>(request);

            _context.Employees.Add(employeeEntity);

            _context.SaveChanges();
        }

        public Employee Get(Guid id)
        {
            EmployeeEntity? employeeEntity = GetEmployeeEntity(id);

            return employeeEntity is null
                ? throw new Exception($"Employee with Id {id} not found.")
                : _mapper.Map<Employee>(employeeEntity);
        }

        public List<Employee> GetAll()
        {
            List<EmployeeEntity> employeeEntities = _context.Employees.ToList();

            List<Employee> employees = _mapper.Map<List<Employee>>(employeeEntities);

            return employees;
        }

        public void Update(UpdateEmployeeRequest request)
        {
            EmployeeEntity? employeeEntity = GetEmployeeEntity(request.Id)
                ?? throw new Exception($"Employee with Id {request.Id} not found.");

            employeeEntity.Name = request.Name;
            employeeEntity.Surname = request.Surname;
            employeeEntity.Salary = request.Salary;
            employeeEntity.Status = (EmployeeStatusEnum)request.Status;
            employeeEntity.LoginUsername = request.LoginUsername;
            employeeEntity.LoginPasswordHashed = request.LoginPasswordHashed;
            employeeEntity.UpdateTime = request.UpdateTime;

            _context.Update(employeeEntity);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            EmployeeEntity? employeeEntity = GetEmployeeEntity(id)
                ?? throw new Exception($"Employee with Id {id} not found.");

            _context.Employees.Remove(employeeEntity);

            _context.SaveChanges();
        }

        private EmployeeEntity? GetEmployeeEntity(Guid id)
        {
            return _context.Employees.FirstOrDefault(c => c.Id == id);
        }
    }
}