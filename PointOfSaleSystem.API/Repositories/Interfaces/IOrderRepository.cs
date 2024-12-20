﻿using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.Order;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public void Create(AddOrderRequest order);
        public Order Get(Guid id);
        public List<Order> GetAll();
        public void Update(UpdateOrderRequest request);
        public void Delete(Guid id);
        public List<Order> GetAllByEmployeeId(Guid employeeId);
        public List<Order> GetOrdersByEmployeeId(Guid employeeId);
    }
}
