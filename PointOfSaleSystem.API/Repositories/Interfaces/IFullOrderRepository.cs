﻿using PointOfSaleSystem.API.Models;
using PointOfSaleSystem.API.RequestBodies.FullOrder;

namespace PointOfSaleSystem.API.Repositories.Interfaces
{
    public interface IFullOrderRepository
    {
        public void Create(FullOrder fullOrder);
        public FullOrder Get(Guid id);
        public List<FullOrder> GetAll();
        public void Update(UpdateFullOrderRequest request);
        public void Delete(Guid id);
        public List<FullOrder> GetAllByEmployeeId(Guid employeeId);
        public List<FullOrder> GetFullOrderByEmployeeId(Guid employeeId);
        public void RefundFullOrder(Guid id);
    }
}
